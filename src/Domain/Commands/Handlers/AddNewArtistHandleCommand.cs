using System;
using Domain.Core;
using Domain.Events;
using Infrastructure.Commands;
using Infrastructure.DomainEvents;

namespace Domain.Commands.Handlers
{
    public class AddNewArtistHandleCommand: IHandleCommand<AddNewArtist>
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public AddNewArtistHandleCommand(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public void Handle(AddNewArtist command)
        {
            var user = _userLoginRepository.Get(command.Creator);
            if(user == null) throw new InvalidOperationException("Username is invalid");
            var artist = Artist.Create(command.Name);
            user.AddArtist(artist);
            DomainEvents.Raise(new ArtistWasAdded() { Artist = artist });
        }
    }
}