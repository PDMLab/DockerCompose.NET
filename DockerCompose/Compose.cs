using System.Text;
using CliWrap;
using CliWrap.Buffered;

namespace DockerCompose;

public class Compose
{
  private readonly DirectoryInfo directory;

  public Compose(
    DirectoryInfo directory
  )
  {
    this.directory = directory;
  }

  public class ComposeResult
  {
    public ComposeResult(
      StringBuilder stdOut,
      StringBuilder stdErr
    )
    {
      StdOut = stdOut;
      StdErr = stdErr;
    }

    public StringBuilder StdOut { get; }
    public StringBuilder StdErr { get; }
  }

  public async Task<ComposeResult> Up()
  {
    var stdOutBuffer = new StringBuilder();
    var stdErrBuffer = new StringBuilder();

    var result = await Cli.Wrap("docker-compose")
      .WithWorkingDirectory(directory.ToString())
      .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
      .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))
      .WithArguments("up -d")
      .ExecuteBufferedAsync();

    var stdOut = stdOutBuffer.ToString();
    var stdErr = stdErrBuffer.ToString();

    return new ComposeResult(
      stdOutBuffer,
      stdErrBuffer
    );
  }

  public async Task<ComposeResult> Stop()
  {
    var stdOutBuffer = new StringBuilder();
    var stdErrBuffer = new StringBuilder();

    var result = await Cli.Wrap("docker-compose")
      .WithWorkingDirectory(directory.ToString())
      .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
      .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))
      .WithArguments("stop")
      .ExecuteBufferedAsync();

    var stdOut = stdOutBuffer.ToString();

    return new ComposeResult(
      stdOutBuffer,
      stdErrBuffer
    );
  }

  public async Task<ComposeResult> Down()
  {
    var stdOutBuffer = new StringBuilder();
    var stdErrBuffer = new StringBuilder();

    var result = await Cli.Wrap("docker-compose")
      .WithWorkingDirectory(directory.ToString())
      .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
      .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))
      .WithArguments("down")
      .ExecuteBufferedAsync();

    var stdOut = stdOutBuffer.ToString();

    return new ComposeResult(
      stdOutBuffer,
      stdErrBuffer
    );
  }
}
