using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs
{
    public class AddDogCommand : IRequest<Dog>
    {
        //DogDto lägg till
        public DogDto NewDog { get; }
        public Guid Id { get; }


        public AddDogCommand(DogDto newDog, Guid id)
        {
            NewDog = newDog;
            Id = id;
        }


    }
}