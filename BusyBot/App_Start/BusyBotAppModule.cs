using Autofac;
using BusyBot.Commands;
using BusyBot.Domain.Readers;
using BusyBot.Extensions;
using BusyBot.Repositories;
using BusyBot.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusyBot
{
    public class BusyBotAppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<QueryCommands>().As<IQueryCommands>();

            builder.RegisterType<GraphEventsRepository>().As<IGraphEventsRepository>();
            builder.RegisterType<GraphUserRepository>().As<IGraphUserRepository>();

            builder.RegisterType<EventReader>().As<IEventReader>();
            builder.RegisterType<UserReader>().As<IUserReader>();
            builder.RegisterType<BotService>().As<IBotService>();
            builder.RegisterType<TemplateService>().As<ITemplateService>();
                       
        }
    }
}