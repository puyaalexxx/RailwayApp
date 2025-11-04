using ErrorOr;
using RailwayApp.Shared.Domain;

namespace RailwayApp.Modules.Trains.Domain.Trains;

public sealed class Train : Entity
{
    public string Name { get; private set; }

    public string Code { get; private set; }

    public Type Type { get; private set; }

    public int Seats { get; private set; }

    public Status Status { get; set; }

    private Train(Guid id, string name, string code, Type type, int seats, Status status) : base(id)
    {
        Name = name;
        Code = code;
        Type = type;
        Seats = seats;
        Status = status;
    }
    
    public static ErrorOr<Train> Create( string name, string code, Type type, int seats, Status status = Status.Running)
    {
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(name))
        {
            errors.Add(Error.Validation(description: "Name cannot be empty."));
        }

        if (string.IsNullOrWhiteSpace(code))
        {
            errors.Add(Error.Validation(description: "Code cannot be empty."));
        }

        if (seats <= 0)
        {
            errors.Add(Error.Validation(description: "Seats must be a positive integer."));
        }
        
        if (errors.Count > 0)
        {
            return errors;
        }

        return new Train( Guid.NewGuid(), name, code, type, seats, status );
    }
}