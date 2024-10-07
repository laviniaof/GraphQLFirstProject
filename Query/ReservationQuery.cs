using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interface;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class ReservationQuery : ObjectGraphType
    {
        public ReservationQuery (IReservationRepository reservationRepository)
        {
            Field<ListGraphType<ReservationType>>("Reservation").Resolve(context =>
            {
                return reservationRepository.GetReservations();
            });
        }
    }
}
