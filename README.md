# Real Time Counter

This repository includes three main parts:

- **AwesomeAlgo Library**: A .NET library that lets you manage number-name pairs and stream them based on divisibility up to a set upper limit.

- **Unit Tests (AwesomeAlgo.Tests)**: Tests to check that everything in the AwesomeAlgo library works correctly.

- **RazorPagesExample**: A sample web project that shows how the AwesomeAlgo library can be used in real-time. It provides a web interface for users to input pairs and see the results streamed live.

This setup helps demonstrate the capabilities of the AwesomeAlgo library through direct application and testing.

# AwesomeAlgo Library

## Overview

The "AwesomeAlgo" library is designed for efficient management and streaming of number-name pairs in .NET 8 applications. It offers functionality to add or replace pairs, retrieve names based on number divisibility, and stream results real-time up to a specified upper boundary.

## Features

- **Add or Replace Pairs**: Efficiently manage your pairs and update them dynamically.
- **Divisibility Streaming**: Stream names based on whether numbers are divisible by the defined pairs up to an upper limit.
- **Built for .NET 8**: Optimized for the latest improvements in .NET technology, ensuring compatibility and performance.

## Getting Started

### Installation

You can include `AwesomeAlgo` directly in your .NET 8 projects. Since this library is not available via NuGet, you will need to integrate it manually into your projects.

### Usage

Here’s how to integrate and use the `AwesomeAlgo` library:

#### Initializing the Library

```csharp
using AwesomeAlgo;

var pairManager = new NumberNamePairManager();
````

#### Adding or Replacing Pairs
````csharp
// Adding a new pair
pairManager.AddOrReplacePair(3, "Fizz");

// Replacing an existing pair
pairManager.AddOrReplacePair(3, "Buzz");
````

## Example Project
Check out the `RazorPagesExample` project in this repository to see `AwesomeAlgo` in action. This project uses Razor Pages to create a web interface where users can input number-name pairs and stream the results in real-time.