using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using Xunit;
using Xunit.Abstractions;
using static WaitForPort.Ports;

namespace DockerCompose.Tests;

public class UpTests
{
  private readonly ITestOutputHelper output;

  public UpTests(
    ITestOutputHelper output
  )
  {
    this.output = output;
  }

  [Fact]
  public async Task ShouldStartContainer()
  {
    var directoryName = Path.GetDirectoryName(
      Assembly.GetAssembly(typeof(UpTests))!
        .Location
    );
    var compose = new Compose(new DirectoryInfo(directoryName!));
    var up = await compose.Up();
    output.WriteLine(up.StdErr.ToString());

    WaitForTcpPort(
      5432,
      10000
    );

    var client = new DockerClientConfiguration()
      .CreateClient();

    var containers = await client.Containers.ListContainersAsync(new ContainersListParameters());
    Assert.Equal(
      1,
      containers.Count
    );
    Assert.Equal(
      "library/postgres:latest",
      containers[0]
        .Image
    );

    var id = containers[0]
      .ID;

    await client.Containers.StopContainerAsync(
      id,
      new ContainerStopParameters()
    );
    await client.Containers.RemoveContainerAsync(
      id,
      new ContainerRemoveParameters()
    );
  }
}
