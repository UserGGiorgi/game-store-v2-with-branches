# Gamestore template

Sample files to setup working CI pipeline.

## Requirements

* Update Visual Studio to latest version (2022+).
* All test should be consolidated in one test project.
* Test project should reference `coverlet.msbuild` package.
* Solution must be located in `Gamestore` folder.

## Installation

Copy [.gitlab-ci.yml](.gitlab-ci.yml) file to repository root folder.  
Copy two files to solution folder
* [Directory.Build.props](Directory.Build.props)
* [.editorconfig](.editorconfig)

## Usage

IDE will highlight errors and suggest fixes based on rule set from `.editorconfig` file which is automatically loaded.  

Pipeline run will be triggered on every push event and run results can be viewed at `merge request` details page or at `CI/CD` -> `Pipelines` section of your project at https://git.epam.com/.
Results will include total test coverage.