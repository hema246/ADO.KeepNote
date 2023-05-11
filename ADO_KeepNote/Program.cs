using System.Data.SqlClient;
using System.Data;

namespace ADO_KeepNote
{
    class KeepNote
    {
        public void CreateNote()
        {
            SqlConnection con = new SqlConnection("Server=IN-F0979S3; database=KeepNote; Integrated Security=true");
            SqlDataAdapter adp = new SqlDataAdapter("Select * from TakeNoteApp", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            var row = ds.Tables[0].NewRow();

            Console.WriteLine("Enter Note title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter description:");
            string descriptions = Console.ReadLine();
            DateTime dates = DateTime.Now;

            row["Title"] = title;
            row["Descriptions"] = descriptions;
            row["Dates"] = dates;

            ds.Tables[0].Rows.Add(row);

            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Database Updated");

        }
        public void ViewAllNote()
        {
            SqlConnection con = new SqlConnection("Server=IN-F0979S3; database=KeepNote; Integrated Security=true");
            SqlDataAdapter adp = new SqlDataAdapter("Select * from TakeNoteApp", con);
            DataSet ds = new DataSet();
            adp.Fill(ds, "NoteApp");
            for (int i = 0; i < ds.Tables["NoteApp"].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables["NoteApp"].Columns.Count; j++)
                {
                    Console.Write($"{ds.Tables["NoteApp"].Rows[i][j]} | ");
                }
                Console.WriteLine();
            }
        }
        public void ViewNoteById()
        {
            SqlConnection con = new SqlConnection("Server=IN-F0979S3; database=KeepNote; Integrated Security=true");
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());

            SqlDataAdapter adp = new SqlDataAdapter($"Select * from TakeNoteApp where id={id}", con);
            DataSet ds = new DataSet();
            adp.Fill(ds, "NoteApp");
            for (int i = 0; i < ds.Tables["NoteApp"].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables["NoteApp"].Columns.Count; j++)
                {
                    Console.Write($"{ds.Tables["NoteApp"].Rows[i][j]} | ");
                }
                Console.WriteLine();
            }
        }
        public void UpdateNote()
        {
            SqlConnection con = new SqlConnection("Server=IN-F0979S3; database=KeepNote; Integrated Security=true");

            Console.WriteLine("Enter id");
            int id = Convert.ToInt32(Console.ReadLine());

            SqlDataAdapter adp = new SqlDataAdapter($"Select * from TakeNoteApp where id={id}", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Console.WriteLine("Enter Note title to update:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter description to update:");
            string descriptions = Console.ReadLine();
            DateTime dates = DateTime.Now;

            ds.Tables[0].Rows[0][1] = title;
            ds.Tables[0].Rows[0][2] = descriptions;
           /* var row = ds.Tables[0].Rows[0];
            row["Title"]=title;
            row["Descriptions"]=descriptions;
            row["Dates"]=dates;*/

            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Database Updated");
        }
        public void DeleteNote()
        {
            SqlConnection con = new SqlConnection("Server=IN-F0979S3; database=KeepNote; Integrated Security=true");

            SqlDataAdapter adp = new SqlDataAdapter("Select * from TakeNoteApp", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            Console.WriteLine("Enter id to delete:");
            int id = Convert.ToInt32(Console.ReadLine());

            ds.Tables[0].Rows[0].Delete();

            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Database Updated");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            KeepNote note = new KeepNote();

            do
            {
                Console.WriteLine("========== KEEP NOTE APP ===========");
                Console.WriteLine("1. CreateNote");
                Console.WriteLine("2. View ALl Notes");
                Console.WriteLine("3. View Note By Id");
                Console.WriteLine("4. Update Note");
                Console.WriteLine("5. Delete Note");
                Console.WriteLine("Enter the choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            note.CreateNote();
                            break;
                        }
                    case 2:
                        {
                            note.ViewAllNote();
                            break;
                        }
                    case 3:
                        {
                            note.ViewNoteById();
                            break;
                        }
                    case 4:
                        {
                            note.UpdateNote();
                            break;
                        }
                    case 5:
                        {
                            note.DeleteNote();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter a valid option");
                            break;
                        }
                }
            } while (true);

        }
    }
}