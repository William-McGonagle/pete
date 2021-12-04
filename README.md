<table>
    <td>
        <img src="./.github/resources/logo.svg">
    </td>
    <td>
        <h1>Pete - An OMTP Library</h1>
        <img alt="GitHub Repo stars" src="https://img.shields.io/github/stars/william-mcgonagle/pete?style=flat">
        <img alt="GitHub top language" src="https://img.shields.io/github/languages/top/william-mcgonagle/pete">
        <img alt="GitHub contributors" src="https://img.shields.io/github/contributors/william-mcgonagle/pete">
        <img alt="GitHub code size in bytes" src="https://img.shields.io/github/languages/code-size/william-mcgonagle/pete">
        <img alt="GitHub repo file count" src="https://img.shields.io/github/directory-file-count/william-mcgonagle/pete">
        <img alt="GitHub issues" src="https://img.shields.io/github/issues/william-mcgonagle/pete">
    </td>
</table>

[![Stargazers repo roster for @William-McGonagle/pete](https://reporoster.com/stars/William-McGonagle/pete)](https://github.com/William-McGonagle/pete/stargazers)

## How to Use

To use Pete, just download the code from github and include it in your project. From there, you can run any of the functions inside of the codebase. At the moment, not all of the functions have Javadoc comments on them, but most of them do. If you choose to use pete, we would love it if you could show the project some love and contribute or try to fund the project. Also, if you could mention that you used pete to build your app or project, that would be great (since were under the MIT license, your not required to mention us at all).

## Features

Pete is the first OMTP library ever built. This means that it is also the oldest and likely most reliable. All of the code was built to be as human-readable as possible and it all is incredibly lightweight. The library overall is only ~500 lines of code, but it uses a ton of spaces to make reading easier. There are also a number of helper functions included in the library to make optimizing and general use of Pete as simple as possible.

### Endpoint-Based Server

The architecture behind pete is endpoint based; this means that users create classes at certain URIs and the server figures out what response to write based on the endpoints. This is an incredibly simple architecture to understand, and it supports a large number of connections with relative ease.

### Response Codes

Pete comes built in with all of the response codes that you will ever need. This means that if you want to respond with a 400 response code, all you need to do is write `BasicResponse.ClientError()`, and pete will automatically generate a response. Every single OMTP response code is accounted for in pete, and this allows for incredible simplicity when writing programs.

### Request and Response Parser

The request and response parser is probably one of the highlights of pete. Since pete uses structs to represent requests and responses and a non-blocking state machine, the performance is incredible. Pete is able to handle millions of response and request parses every second without problem. The only limit to pete is your computer.

## License

Copyright 2021 William McGonagle

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

The software is provided "as is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or other dealings in the software.
