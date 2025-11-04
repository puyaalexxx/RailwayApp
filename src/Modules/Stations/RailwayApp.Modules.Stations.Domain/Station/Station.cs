using ErrorOr;
using RailwayApp.Shared.Domain;

namespace RailwayApp.Modules.Stations.Domain.Station;

public sealed class Station : Entity
{
    public string Name { get; private set; }

    public Address Address { get; private set; }

    public bool HasWc { get; private set; }
    
    public bool HasCoffeeMachine { get; private set; }
    
    public bool HasWaitingRoom { get; private set; }
    
    private Station(Guid id, string name, Address address, bool hasWc, bool hasCoffeeMachine, bool hasWaitingRoom)
        : base(id)
    {
        Name = name;
        Address = address;
        HasWc = hasWc;
        HasCoffeeMachine = hasCoffeeMachine;
        HasWaitingRoom = hasWaitingRoom;
    }
    
    /// <summary>
    /// Factory method to create a new Station instance with validation.
    /// </summary>
    /// <param name="name">The name of the station. Cannot be empty.</param>
    /// <param name="address">The address of the station. Must not be null.</param>
    /// <param name="hasWc">Indicates whether the station has a WC.</param>
    /// <param name="hasCoffeeMachine">Indicates whether the station has a coffee machine.</param>
    /// <param name="hasWaitingRoom">Indicates whether the station has a waiting room. </param>
    /// <returns>
    /// Returns a <see cref="ErrorOr{Station}"/> containing the created Station if valid,
    /// or a list of validation errors if any of the constraints are violated.
    /// </returns>
    public static ErrorOr<Station> Create(string name, Address address, bool hasWc = false, bool hasCoffeeMachine = false, bool hasWaitingRoom = false)
    {
        var errors = new List<Error>();

        if (string.IsNullOrWhiteSpace(name))
        {
            errors.Add(Error.Validation("Station Name cannot be empty."));
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Station(Guid.NewGuid(), name, address, hasWc, hasCoffeeMachine, hasWaitingRoom);
    }
}