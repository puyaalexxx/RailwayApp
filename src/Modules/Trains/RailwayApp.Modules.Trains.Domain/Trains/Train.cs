using ErrorOr;
using RailwayApp.Shared.Domain;
using TrainStop = RailwayApp.Modules.Trains.Domain.Stop.Stop;

namespace RailwayApp.Modules.Trains.Domain.Trains;

public sealed class Train : Entity
{
    public string Name { get; private set; }

    public string Number { get; private set; }

    public Type Type { get; private set; }

    public int Seats { get; private set; }

    public Status Status { get; set; }
    
    private List<TrainStop> _stops = new(); 
    public IReadOnlyList<TrainStop> Stops => _stops.AsReadOnly();

    private Train(Guid id, string name, string number, Type type, int seats, Status status) : base(id)
    {
        Name = name;
        Number = number;
        Type = type;
        Seats = seats;
        Status = status;
    }
    
    /// <summary>
    /// Factory method to create a new Train instance with validation.
    /// </summary>
    /// <param name="name">The name of the train. Cannot be empty.</param>
    /// <param name="number">The train number or code. Cannot be empty.</param>
    /// <param name="type">The type of the train.</param>
    /// <param name="seats">The total number of seats. Must be a positive integer.</param>
    /// <param name="status">The initial status of the train.</param>
    /// <returns>
    /// Returns a <see cref="ErrorOr{Train}"/> containing the created Train if valid,
    /// or a list of validation errors if any of the constraints are violated.
    /// </returns>
    public static ErrorOr<Train> Create( string name, string number, Type type, int seats, Status status = Status.Running)
    {
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(name))
        {
            errors.Add(Error.Validation(description: "Train Name cannot be empty."));
        }

        if (string.IsNullOrWhiteSpace(number))
        {
            errors.Add(Error.Validation(description: "Train Number cannot be empty."));
        }

        if (seats <= 0)
        {
            errors.Add(Error.Validation(description: "Seats must be a positive integer."));
        }
        
        if (errors.Count > 0)
        {
            return errors;
        }

        return new Train( Guid.NewGuid(), name, number, type, seats, status );
    }
    
    /// <summary>
    /// Adds a new stop to the train's schedule.
    /// </summary>
    /// <param name="stationId">The unique identifier of the station for this stop.</param>
    /// <param name="arrivalUtc">The scheduled arrival time at the station in UTC.</param>
    /// <param name="departureUtc">The scheduled departure time from the station in UTC.</param>
    public void AddStop(Guid stationId, DateTime arrivalUtc, DateTime departureUtc)
    {
        _stops.Add(new TrainStop(stationId, arrivalUtc, departureUtc));
    }
}