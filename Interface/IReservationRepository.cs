using GraphQLProject.Models;

namespace GraphQLProject.Interface
{
    public interface IReservationRepository
    {
        List<Reservation> GetReservations();
        Reservation AddReservation(Reservation reservation);
    }
}
