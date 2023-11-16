using Cosmetic_App.Utiltes;
using iText.IO.Image;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Tables
{
    public class Income:DB_Object
    {
        Person Client { get; set; } = new Person();
        Workers Worker { get; set; } = new Workers();
        List<Products> Cart {  get; set; } = new List<Products>();
        List<Cart> shopingCart { get; set; }=new List<Cart>();
        List<Calender_Table> Apooitments { get; set; } = new List<Calender_Table>();
        public Income() : base(Database_Names.Income,Database_Names.Income_Columes)
        {
            Value =GetNewIndex();
            SetColValue(4, DateTime.Now.ToShortDateString() + " " +DateTime.Now.ToShortTimeString());
        }
        public Income(DB_Object obj) : base(obj)
        {

        }
        public Income (int id):base(Database_Names.Income, Database_Names.Income_Columes)
        {
            Grab(id);
        }
        public bool Grab(int id)
        {
            bool result =base.Grab(id);
            result &= Client.Grab(GetColValue(Database_Names.Income_Columes[2]));
            result &= Worker.Grab(GetColValue(Database_Names.Income_Columes[3]));            
            Cart = GrabOrderCart(id);
            Apooitments = GrabApooitments(id);
            return result;
        }
        public void ReloadApooitments()
        {
            Apooitments = GrabApooitments((int)Value);
        }
        private List<Calender_Table> GrabApooitments(int id)
        {
            List<Calender_Table> apooitments = new List<Calender_Table>();
            foreach (DB_Object obj in Grab(Database_Names.Calender_Columes[4], id, Database_Names.Calendrer))
                apooitments.Add(new Calender_Table((int)obj.Value));
            return apooitments;
        }
        private List<Products> GrabOrderCart(int id)
        {
            List<Products> products = new List<Products>();
            foreach (DB_Object obj in Grab(Database_Names.Cart_Columes[1], id, Database_Names.Cart))
            {
                Products p = new Products((int)obj.GetColValue(Database_Names.Cart_Columes[2]));
                p.Row.Columes.Add(new Col("amonut", obj.GetColValue(Database_Names.Cart_Columes[3])));
                products.Add(p);
            }
            return products;
        }
        public List<Products> GetCart()
        {
            return Cart;
        }
        public void SetClient(string id){Client.Grab(id);}
        public void SetClient(Person person){ Client = person; }
        public void SetWorker(string id) { Worker.Grab(id); }
        public void SetCart(int id) { Cart = GrabOrderCart(id); }
        public void SetCart(List<Cart> cart) { shopingCart = cart; }
        public int GetOrderId() { return (int)GetColValue(0); }
        public string GetClientName() { return Client.GetFullName(); }
        public string GetWorkerName() { return Worker.GetFullName(); }
        public Products GetProduct(int id)
        {
            foreach (Products Product in Cart)
                if ((int)Product.Value == id)
                    return Product;
            return null;
        }
        public Calender_Table GetAppoitment(int product_id)
        {
            foreach(Calender_Table appoitment in Apooitments)
                if ((int)appoitment.GetColValue(Database_Names.Calender_Columes[3])==product_id)
                    return appoitment;
            return null;
        }
        public int GetAppoitmentId(int product_id)
        {
            foreach (Calender_Table appoitment in Apooitments)
                if ((int)appoitment.GetColValue(Database_Names.Calender_Columes[3]) == product_id)
                    return (int)appoitment.Value;
            return -1;
        }
        public bool IsTreatmentSchedule(int id)
        {
            foreach(Calender_Table appoitment in Apooitments)
            {
                if((int)appoitment.GetProduct().Value == id)
                    return true;
            }
            return false;
        }

        internal Person GetClient()
        {
            return Client;
        }

        internal void Relaod()
        {
            Grab((int)Value);
        }
        public void CreateInvoce(string path,object signture)
        {
            Document doc = new Document(PageSize.A4);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();
                doc.Add(GetElements("date"));
                doc.Add(GetElements("title"));
                doc.Add(GetElements("client"));
                doc.Add(GetList());
                doc.Add(ConvertBitmapToIElement(signture));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
                MessageBox.Show("OK");
            }

        }

        public IElement ConvertBitmapToIElement(object bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                try
                {
                    // Save the Bitmap to the MemoryStream in the desired format (e.g., PNG)
                    ((Bitmap)bitmap).Save(stream, ImageFormat.Png);
                }
                catch (Exception e){
                    MessageBox.Show(e.Message);
                }
                // Create an Image object using iTextSharp
                iText.Layout.Element.Image image = new iText.Layout.Element.Image(ImageDataFactory.Create(stream.ToArray()));

                // Optionally, set image dimensions or other properties
                image.SetWidth(200);
                image.SetHeight(200);
                return (IElement)image;
            }
        }

        public PdfPTable GetList()
        {

            PdfPTable table = new PdfPTable(4);
            table.AddCell(getCell(GetElements( Messages.Reverse("מחיר")),"header"));
            table.AddCell(getCell(GetElements(Messages.Reverse("כמות")),"header")) ;
            table.AddCell(getCell(GetElements(Messages.Reverse("מחיר ליחידה")), "header"));
            table.AddCell(getCell(GetElements(Messages.Reverse("שם מוצר")), "header"));
            int total = 0;
            
            foreach (Cart cart in shopingCart)
            {
                
                table.AddCell(getCell((GetElements(Messages.Reverse("ש''ח") + cart.GetTotal())),"body"));
                table.AddCell(getCell(GetElements(cart.GetAmount().ToString()),"body"));
                table.AddCell(getCell(GetElements(cart.GetPrice().ToString()),"body"));
                table.AddCell(getCell(GetElements(Messages.Reverse(cart.GetName())), "body"));
                total += cart.GetAmount() * cart.GetPrice();
            }
            table.AddCell(getCell(GetElements(Messages.Reverse("ש''ח")+total.ToString()),"body"));
            table.AddCell("");
            table.AddCell("");
            table.AddCell(getCell(GetElements(Messages.Reverse("סה''כ")), "body"));
            return table;
        }
        private PdfPCell getCell(Paragraph message, string type)
        {
            PdfPCell cell = new PdfPCell(message);
            switch (type) {
                case "header":
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                    break;
                case "body":
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    break;
                case "side":
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                    break;
            }
            return cell;
        }
        public int GetTotal()
        {
            return (int)GetColValue("total");
        }

        public Paragraph GetElements(string type)
        {
            Paragraph p = new Paragraph();
            BaseFont baseFont = BaseFont.CreateFont("c:/windows/fonts/david.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            string message;
            switch (type)
            {
                case "title":
                    p.Font = new iTextSharp.text.Font(baseFont, 40);
                    p.Alignment = Element.ALIGN_CENTER;
                    p.Add(Messages.Reverse($"קבלה מספר\n\n{Value}\n\n"));

                    return p;
                case "client":
                    p.Font = new iTextSharp.text.Font(baseFont, 20);
                    p.Alignment = Element.ALIGN_RIGHT;
                    p.Add(Messages.Reverse($"לקוח:\t{Client.GetFullName()}\nעובד:\t{Worker.GetFullName()}\n\n"));
                    return p;
                case "list":
                    break;
                case "signiture":
                    break;
                case "total":
                    break;
                case "date":
                    p.Font = new iTextSharp.text.Font(baseFont, 14);
                    p.Alignment = Element.ALIGN_RIGHT;
                    p.Add(GetColValue(4)+" "+ Messages.Reverse("תאריך")+"\n\n\n");
                    return p;
                default:
                    p.Font = new iTextSharp.text.Font(baseFont, 16);
                    p.Alignment = Element.ALIGN_RIGHT;
                    p.Add(type);
                    return p;
            }
            return null;
        }
    }
}
