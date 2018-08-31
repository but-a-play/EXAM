using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MODEL;
using System.Collections;

namespace EXAM
{
    public partial class Seat : System.Web.UI.Page
    {
        private BLL.Roster rosterService = new BLL.Roster();
        private BLL.Seat seatService = new BLL.Seat();
        protected void Page_Load(object sender, EventArgs e)
        {
            //int[] a = { 1, 2, 3, 4, 5, 6 };
            //int[] b = { 7, 8, 9, 10, 11 };

            ArrayList AList = rosterService.GetRosterInfoByExamType("A类");
            ArrayList BList = rosterService.GetRosterInfoByExamType("B类");
            ArrayList CList = rosterService.GetRosterInfoByExamType("C类");
            //SeatInfo[] ASeats = seatService.SetSeat(AList);
            //SeatInfo[] BSeats = seatService.SetSeat(BList);
            //SeatInfo[] CSeats = seatService.SetSeat(CList);

            //SeatInfo[] ASeats = seatService.SetSeat2(AList);
            //SeatInfo[] BSeats = seatService.SetSeat2(BList);
            //SeatInfo[] CSeats = seatService.SetSeat2(CList);

            SeatInfo[] ASeats = seatService.SetSeat3(AList);
            SeatInfo[] BSeats = seatService.SetSeat3(BList);
            SeatInfo[] CSeats = seatService.SetSeat3(CList);
            SeatInfo[] room1Seats = new SeatInfo[60];
            SeatInfo[] room2Seats = new SeatInfo[50];

            ArrayList finalList = new ArrayList();


            for (int r1Index = 0; r1Index < room1Seats.Length; ++r1Index)
            {
                if (r1Index < CSeats.Length)
                {
                    room1Seats[r1Index] = CSeats[r1Index];

                }
                else
                {
                    room1Seats[r1Index] = BSeats[r1Index - CSeats.Length];
                }
                room1Seats[r1Index].Room = "教室甲";
                room1Seats[r1Index].SeatNo = r1Index + 1;
                finalList.Add(room1Seats[r1Index]);
            }
            for (int r2Index = 0; r2Index < room2Seats.Length - (room1Seats.Length + room2Seats.Length - CSeats.Length - BSeats.Length - ASeats.Length); ++r2Index)
            {
                if (r2Index < BSeats.Length - room1Seats.Length + CSeats.Length)
                {
                    room2Seats[r2Index] = BSeats[r2Index + room1Seats.Length - CSeats.Length];

                }
                else
                {
                    room2Seats[r2Index] = ASeats[r2Index - BSeats.Length + room1Seats.Length - CSeats.Length];
                }

                room2Seats[r2Index].Room = "教室乙";
                room2Seats[r2Index].SeatNo = r2Index + 1;
                finalList.Add(room2Seats[r2Index]);
            }

            seatService.AddSeatData(finalList, "seat5");

        }
    }
}