# DockerCompose.NET

This is a library to automate `docker-compose` 2.x using .NET.

## Usage

### Starting containers

```csharp
var directoryName = Path.GetDirectoryName("/path/to/directory-with-compose-file");
var compose = new Compose(new DirectoryInfo(directoryName!));
var up = await compose.Up();
```

### Stopping containers

```csharp
var directoryName = Path.GetDirectoryName("/path/to/directory-with-compose-file");
var compose = new Compose(new DirectoryInfo(directoryName!));
var up = await compose.Stop();
```

### Removing containers

```csharp
var directoryName = Path.GetDirectoryName("/path/to/directory-with-compose-file");
var compose = new Compose(new DirectoryInfo(directoryName!));
var up = await compose.Down();
```

## Want to help?

This project is just getting off the ground and could use some help with cleaning things up and refactoring.

If you want to contribute - we'd love it! Just open an issue to work against so you get full credit for your fork. You
can open the issue first so we can discuss and you can work your fork as we go along.

If you see a bug, please be so kind as to show how it's failing, and we'll do our best to get it fixed quickly.

Before sending a PR, please [create an issue](https://github.com/PDMLab/DockerCompose.NET/issues/new) to introduce your
idea and have a reference for your PR.

We're using [conventional commits](https://www.conventionalcommits.org), so please use it for your commits as well.

## License

MIT License

Copyright (c) 2022 PDMLab

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
