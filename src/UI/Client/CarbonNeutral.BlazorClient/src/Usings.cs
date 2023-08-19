global using Microsoft.JSInterop;
global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
global using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
global using Microsoft.AspNetCore.Components.WebAssembly.Services;
global using Microsoft.AspNetCore.SignalR;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using MudBlazor.Services;

global using System;
global using System.Collections.Generic;
global using System.Globalization;
global using System.Linq;
global using System.Net.Http;
global using System.Net.Http.Json;
global using System.Text.Json;
global using System.Security.Claims;

global using CarbonNeutral.KernelShared.Configuration;
global using CarbonNeutral.Common;
global using CarbonNeutral.Common.Interfaces;
global using CarbonNeutral.Common.Services;
global using CarbonNeutral.BlazorClient;
global using CarbonNeutral.BlazorClient.Interfaces;
global using CarbonNeutral.BlazorClient.Services;

// ----------------------------------------------------------------//
// AccountModule
global using AccountModuleCore.TestData.Entities;
global using AccountModuleApplication.Shared.Interfaces;
global using AccountModuleApplication.Shared.Services;
global using AccountModuleApplication.Shared.Requests;
global using AccountModuleApplication.Shared.ViewModels;
global using AccountModuleClientServiceLoader;
// \AccountModule

// LiveRoomModule
global using LiveRoomCore.LiveRoomTestData.Entities;
global using LiveRoomApplication.Shared.Interfaces;
global using LiveRoomApplication.Shared.Services;
global using LiveRoomApplication.Shared.Requests;
global using LiveRoomApplication.Shared.ViewModels;             
global using LiveRoomModuleClientServiceLoader;
// \LiveRoomModule

// WordSearchKingdom
global using WskCore.WskTestData.Entities;
global using WskApplication.Shared.Interfaces;
global using WskApplication.Shared.Services;
global using WskApplication.Shared.Requests;
global using WskApplication.Shared.ViewModels;
global using WskModuleClientServiceLoader;
// \WordSearchKingdom
