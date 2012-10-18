using Gateway;
using Gateway.Interfaces;
using Infrastructure.Commands;

namespace Domain.Commands.Handlers
{
    public class FindArtistInformationOnExternalServicesHandler: IHandleCommand<FindArtistInformationOnExternalServices>
    {
        private readonly IExternalApiGateway _externalApiGateway;

        public FindArtistInformationOnExternalServicesHandler(IExternalApiGateway externalApiGateway )
        {
            _externalApiGateway = externalApiGateway;
        }

        public void Handle(FindArtistInformationOnExternalServices command)
        {
            _externalApiGateway.SearchExternalApis(command.Artist.Name);
        }
    }
}