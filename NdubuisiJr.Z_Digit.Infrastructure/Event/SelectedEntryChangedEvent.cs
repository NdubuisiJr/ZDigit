using NdubuisiJr.Z_Digit.Domain;
using Prism.Events;

namespace NdubuisiJr.Z_Digit.Infrastructure.Event
{
    public class SelectedEntryChangedEvent : PubSubEvent<Entity> { }
}