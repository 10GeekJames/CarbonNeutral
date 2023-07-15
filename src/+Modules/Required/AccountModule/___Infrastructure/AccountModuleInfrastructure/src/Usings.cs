global using Ardalis.EFCore.Extensions;
global using Ardalis.GuardClauses;
global using Ardalis.Specification.EntityFrameworkCore;

global using CarbonNeutral.KernelShared;
global using CarbonNeutral.KernelShared.Interfaces;

global using AccountModuleCore;
global using AccountModuleCore.Entities;
global using AccountModuleCore.Specifications;
global using AccountModuleCore.Interfaces;

global using AccountModuleInfrastructure.CommandQuery;
global using AccountModuleInfrastructure.Data;

global using Autofac;
global using MediatR;
global using MediatR.Pipeline;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using System.ComponentModel.DataAnnotations;

global using System.Net.Mail;
global using System.Reflection;
global using Module = Autofac.Module;