using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs
{
    public class AddDogCommand : IRequest<Dog>
    {
        public DogDto NewDog { get; }


        public AddDogCommand(DogDto newDog)
        {
            NewDog = newDog;
        }

       
    }
}
