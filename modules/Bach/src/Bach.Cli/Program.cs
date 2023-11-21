﻿// Module Name: Program.cs
// Project:     Bach.Cli
// Copyright (c) 2012, 2023  Eddie Velasquez.
//
// This source is subject to the MIT License.
// See http://opensource.org/licenses/MIT.
// All other rights reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software
// and associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to
// do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial
// portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
// PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.CommandLine.Parsing;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace Bach.Cli;

internal static class Program
{
#region Public Methods

  public static async Task<int> Main( string[] args )
  {
    var rootCommand = new BachRootCommand();
    var parser = new CommandLineBuilder( rootCommand ).UseDefaults()
                                                      .UseHelp( ctx => ctx.HelpBuilder.CustomizeLayout(
                                                                  _ => HelpBuilder.Default.GetLayout()
                                                                    .Skip( 1 )
                                                                    .Prepend( _ => AnsiConsole.Write(
                                                                                new FigletText(
                                                                                  rootCommand.Description! ).Color(
                                                                                  Color.CadetBlue ) ) ) ) )
                                                      .Build();

    return await parser.InvokeAsync( args );
  }

#endregion
}
