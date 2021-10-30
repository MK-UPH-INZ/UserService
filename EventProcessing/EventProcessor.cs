using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UserService.Data;
using UserService.DTO;
using UserService.Models;

namespace UserService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly IMapper mapper;

        public EventProcessor(
            IServiceScopeFactory scopeFactory,
            IMapper mapper
        ) {
            this.scopeFactory = scopeFactory;
            this.mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.RestaurantPublished:
                    // TO DO
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            var eventType = JsonSerializer.Deserialize<GenericEventDTO>(notificationMessage);

            switch( eventType.Event )
            {
                case "Restaurant_Published":
                    return EventType.RestaurantPublished;
                default:
                    return EventType.Undetermined;
            }
        }

        private void addRestaurant(string restaurantPublishedMessage)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var restaurantRepository = scope.ServiceProvider.GetRequiredService<IRestaurantRepo>();

                var restaurantPublishedDto = JsonSerializer.Deserialize<RestaurantPublishedDTO>(restaurantPublishedMessage);

                try
                {
                    var restaurant = mapper.Map<Restaurant>(restaurantPublishedDto);

                    if(!restaurantRepository.ExternalRestaurantExists(restaurant.ExternalId))
                    {
                        restaurantRepository.CreateRestaurant(restaurant);
                        restaurantRepository.SaveChanges();
                    }
                } catch( Exception e )
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

    enum EventType
    {
        RestaurantPublished,
        Undetermined
    }
}
