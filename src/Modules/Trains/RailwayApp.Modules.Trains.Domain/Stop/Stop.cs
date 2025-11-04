using ErrorOr;

namespace RailwayApp.Modules.Trains.Domain.Stop;

public sealed class Stop
{
    public Guid StationId { get; private set; }
    
    public DateTime DepartureTimeUtc { get; private set; }
    
    public DateTime ArrivalTimeUtc { get; private set; }
    
    public Stop(Guid stationId, DateTime departureTimeUtc, DateTime arrivalTimeUtc)
    {
        StationId = stationId;
        DepartureTimeUtc = departureTimeUtc;
        ArrivalTimeUtc = arrivalTimeUtc;
    }
    
    /// <summary>
    /// Creates a new <see cref="Stop"/> instance and validates its invariants.
    /// </summary>
    /// <param name="stationId">The unique identifier of the station where the stop occurs.</param>
    /// <param name="departureTimeUtc">The scheduled departure time in UTC.</param>
    /// <param name="arrivalTimeUtc">The scheduled arrival time in UTC.</param>
    /// <returns>
    /// Returns an <see cref="ErrorOr{Stop}"/> containing the newly created <see cref="Stop"/> 
    /// if all validations pass, or a list of validation errors otherwise.
    /// </returns>
    public static ErrorOr<Stop> Create(Guid stationId, DateTime departureTimeUtc, DateTime arrivalTimeUtc)
    {
        var errors = new List<Error>();

        if (departureTimeUtc < DateTime.UtcNow)
        {
            errors.Add(Error.Validation("Departure time cannot be in the past."));
        }

        if (departureTimeUtc >= arrivalTimeUtc)
        {
            errors.Add(Error.Validation("Departure time must be earlier than arrival time."));
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Stop(stationId, departureTimeUtc, arrivalTimeUtc);
    }
}