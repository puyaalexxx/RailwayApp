using ErrorOr;
using RailwayApp.Shared.Domain;

namespace RailwayApp.Modules.Trains.Domain.Route;

public sealed class Route : Entity
{
    public string Name { get; private set; }

    public string StartStation { get; private set; }

    public string EndStation { get; private set; }
    
    private Route(Guid id, string name, string startStation, string endStation)
        : base(id)
    {
        Name = name;
        StartStation = startStation;
        EndStation = endStation;
    }

    public static ErrorOr<Route> Create(string name, string startStation, string endStation)
    {
        List<Error> errors = [];
        
        if (string.IsNullOrWhiteSpace(name))
        {
            errors.Add(Error.Validation(description: "Route name cannot be empty."));
        }

        if (string.IsNullOrWhiteSpace(startStation))
        {
            errors.Add(Error.Validation(description: "Start station cannot be empty."));
        }

        if (string.IsNullOrWhiteSpace(endStation))
        {
            errors.Add(Error.Validation(description: "End station cannot be empty."));
        }
        
        if (string.Equals(startStation, endStation, StringComparison.OrdinalIgnoreCase))
        {
            errors.Add(Error.Validation(description: "Start and end stations cannot be the same."));
        }

        if (errors.Count > 0)
        {
            return errors;
        }
        
        return new Route(Guid.NewGuid(), name, startStation, endStation);
    }
}