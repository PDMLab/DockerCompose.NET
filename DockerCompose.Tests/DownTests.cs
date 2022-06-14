using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using Xunit;
using Xunit.Abstractions;
using static WaitForPort.Ports;

namespace DockerCompose.Tests;

public class DownTests
{
  private readonly ITestOutputHelper output;

  public DownTests(
    ITestOutputHelper output
  )
  {
    this.output = output;
  }

  [Fact]
  public async Task ShouldRemoveContainer()
  {
    var directoryName = Path.GetDirectoryName(
      Assembly.GetAssembly(typeof(DownTests))!
        .Location
    );
    var compose = new Compose(new DirectoryInfo(directoryName!));
    var up = await compose.Up();
    output.WriteLine(up.StdErr.ToString());

    WaitForTcpPort(
      5432,
      15000
    );

    var client = new DockerClientConfiguration()
      .CreateClient();

    var containersAfterUp = await client.Containers.ListContainersAsync(new ContainersListParameters());
    Assert.Equal(
      1,
      containersAfterUp.Count
    );
    Assert.Equal(
      "library/postgres:latest",
      containersAfterUp[0]
        .Image
    );

    await compose.Down();

    var containersAfterDown =
      await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true });

    Assert.Equal(
      0,
      containersAfterDown.Count
    );
  }
}
