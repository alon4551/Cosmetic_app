using Cosmetic_App.Utiltes;
using iText.IO.Image;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Cosmetic_App.Tables
{
    public class Income:DB_Object
    {//Object represeting Income Table, connected to People, Worker,Cart,Calender Tables
        Person Client { get; set; } = new Person();
        Workers Worker { get; set; } = new Workers();
        List<Products> Cart {  get; set; } = new List<Products>();
        List<Cart> shopingCart { get; set; }=new List<Cart>();
        List<Calender_Table> Apooitments { get; set; } = new List<Calender_Table>();
        //
        public Income() : base(Database_Names.Income,Database_Names.Income_Columes)
        {//inislaizeing new Income object
            Table = Database_Names.Income;
            Value =GetNewIndex();
            SetColValue(0, Value);
            SetColValue(4, DateTime.Now.ToShortDateString() + " " +DateTime.Now.ToShortTimeString());
            SetColValue(5, false);
        }
        public Income(Row r) : base(r)
        {//createing new income object based on r data
            Table = Database_Names.Income;
            Value = r.GetColValue(0);
            Worker = Workers.GetWorker(GetColValue("worker").ToString());
            Client = Person.GetPerson(GetColValue("client").ToString());
            shopingCart = GetOrderCart((int)Value);
            Cart = GrabOrderCart((int)Value);
            Apooitments = GrabApooitments((int)Value);
        }
        public static List<Income> GrabAll()
        {//featching all incomes from DB
            List<DB_Object> list = DB_Object.GrabAll(Database_Names.Income);
            List<Income> all = new List<Income>();
            foreach(DB_Object obj in list)
                all.Add(new Income(obj));
            return all;
        }
        public Income(DB_Object obj) : base(obj)
        {//createing new Income object based data from obj
            Value =obj.Value;
            SetColValue(0, Value);
            Table = Database_Names.Income;
            Worker = Workers.GetWorker(GetColValue("worker").ToString());
            Client = Person.GetPerson(GetColValue("client").ToString());
            shopingCart = GetOrderCart((int)Value);
            Cart = GrabOrderCart((int)Value);
            Apooitments = GrabApooitments((int)Value);
        }
        public Income (int id):base(Database_Names.Income, Database_Names.Income_Columes)
        {//featching income from DB based id value
            Grab(id);
        }
        public bool Grab(int id)
        {//getting order from DB
            Value = id;
            bool result =base.Grab(id);
            Worker = Workers.GetWorker(GetColValue("worker").ToString());
            Client = Person.GetPerson(GetColValue("client").ToString());
            Cart = GrabOrderCart(id);
            shopingCart = GetOrderCart((int)Value);
            Apooitments = GrabApooitments(id);
            return result;
        }
        public void ReloadApooitments()
        {//reloading appoitment from DB
            Apooitments = GrabApooitments((int)Value);
        }
        private List<Calender_Table> GrabApooitments(int id)
        {//getting all appoitment from DB
            List<Calender_Table> apooitments = new List<Calender_Table>();
            foreach (DB_Object obj in Grab(Database_Names.Calender_Columes[4], id, Database_Names.Calendrer))
                apooitments.Add(new Calender_Table((int)obj.Value));
            return apooitments;
        }
        private List<Products> GrabOrderCart(int id)
        {//getting all cart from DB
            List<Products> products = new List<Products>();
            foreach (DB_Object obj in Grab(Database_Names.Cart_Columes[1], id, Database_Names.Cart))
            {
                Products p = new Products((int)obj.GetColValue(Database_Names.Cart_Columes[2]));
                p.Row.Columes.Add(new Col("amonut", obj.GetColValue(Database_Names.Cart_Columes[3])));
                products.Add(p);
            }
            return products;
        }
        public List<Cart> GetOrderCart(int id)
        {//getting shoping cart of order
            List<Cart> cart = new List<Cart>();
            foreach (DB_Object obj in Grab(Database_Names.Cart_Columes[1], id, Database_Names.Cart))
                cart.Add(new Cart(obj));
            return cart;
        }
        public bool IsShopingCartScheduale()
        {//returning if all the appoitments of order are schdule
            int count;
            bool state = true;
            foreach(Cart item in shopingCart)
            {
                if (item.Product.IsTreatment())
                {
                    if (item.GetAmount() != 1)
                    {
                        count = 0;
                        foreach (Calender_Table appoitment in Apooitments)
                            if (appoitment.GetColValue(3).ToString() == item.Value.ToString())
                             count++;
                        if (count != item.GetAmount())
                            state = false;
                    }
                    else
                    {
                        bool search = false;
                        foreach (Calender_Table appoitment in Apooitments)
                            if ((int)appoitment.GetColValue(3) == (int)item.Value)
                                search = true;
                        if (!search)
                            state = false;
                    }
                }
            }
            return state;
        }
        public List<Cart> GetCart()
        {//return shoping cart
            return shopingCart;
        }
        public void AddItem(Products item)
        {//adding item to shoping cart
            Cart cart =new Cart((int)Value, item);
            cart.SetAmount(1);
            cart.Insert();
            shopingCart.Add(cart);
        }
        public void RemoveItem(int index)
        {//removing item from shoping cart
            shopingCart[index].Delete();
            shopingCart.RemoveAt(index);
        }
        public void SetClient(string id){//setting client to order
            Client = Person.GetPerson(id);
            SetColValue(2, id);
        }
        public void SetClient(Person person){//setting client to order
            Client = person;
            SetColValue(2, person.Value);
        }
        public void SetWorker(string id) {//setting worker to order
            Worker = Workers.GetWorker(id);
            SetColValue(3, id); 
        }
        public void SetCart(int id) { Cart = GrabOrderCart(id); }//seeting shoping cart
        public void SetCart(List<Cart> cart) {//setting shoping cart to order
            shopingCart = cart;
            int total = 0;
            foreach (Cart cartItem in shopingCart)
                total += cartItem.GetTotal();
            SetColValue(Database_Names.Income_Columes[1],total);
        }
        public int GetOrderId() { return (int)GetColValue(0); }
        public string GetClientName() { return Client.GetFullName(); }
        public string GetWorkerName() { return Worker.GetFullName(); }
 
        public Products GetProduct(int id)//return product infomation from shoping cart
        {
            foreach (Products Product in Cart)
                if ((int)Product.Value == id)
                    return Product;
            return null;
        }
        public Calender_Table GetAppoitment(int product_id)//returning appoitment information from  shoping cart
        {
            foreach(Calender_Table appoitment in Apooitments)
                if ((int)appoitment.GetColValue(Database_Names.Calender_Columes[3])==product_id)
                    return appoitment;
            return null;
        }
        public Calender_Table Get_Apooitment(int Cart_id)//getting appotment information form shoping cart
        {
            foreach (Calender_Table appoitment in Apooitments)
                if ((int)appoitment.GetColValue(Database_Names.Calender_Columes[3]) == Cart_id)
                    return appoitment;
            return null;
        }
        public int GetAppoitmentId(int Cart_id)//getting appotment information form shoping cart
        {
            foreach (Calender_Table appoitment in Apooitments)
                if ((int)appoitment.GetColValue(Database_Names.Calender_Columes[3]) == Cart_id)    
                    return (int)appoitment.Value;
            return -1;
        }
        public bool IsTreatmentSchedule(int cart_id)//checking if appotment form shoping cart is schedule
        {
            foreach (Calender_Table appoitment in Apooitments)
            {
                if ((int)appoitment.GetColValue(3) == cart_id)
                    return true;
            }
            return false;
        }
        public bool IsTreatmentSchedule(Cart cart)//checking if appotment form shoping cart is schedule
        {
            foreach(Calender_Table appoitment in Apooitments)
            {
                if((int)appoitment.GetColValue(3) == (int)cart.Value)
                    return true;
            }
            return false;
        }

        internal Person GetClient()
        {
            return Client;
        }

        internal void Relaod()
        {//reload information from DB
            Grab((int)Value);
        }
        public void CreateRefund(string path)//creating refund PDF file 
        {
            Document doc = new Document(PageSize.A5);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();
                doc.Add(GetElements("date"));
                doc.Add(GetElements("refund"));
                doc.Add(GetElements("client"));
                doc.Add(GetElements("price"));
                doc.Add(new Paragraph("\n\n\n\n"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                doc.Close();
                MessageBox.Show($"טופס זיכוי נמצא בכתובת\n{path}");
            }
        }
        public void CreateInvoce(string path,object signture)//create invoce PDF file
        {
            Document doc = new Document(PageSize.A5);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();
                doc.Add(GetElements("date"));
                doc.Add(GetElements("title"));
                doc.Add(GetElements("client"));
                doc.Add(GetList());
                doc.Add(new Paragraph("\n\n\n\n"));
                doc.Add(getSignature((Bitmap)signture));
                doc.Add(new Paragraph(Messages.Reverse("הוספה פרטי עסק")));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                doc.Close();

                MessageBox.Show($"טופס קבלה נמצא בכתובת\n{path}");
            }

        }
        public Paragraph getSignature(Bitmap signatureBitmap)//getting signature frm client
        {
            Paragraph p =new Paragraph();
            int size = 128;
            Bitmap resize = new Bitmap(size,size);
            using(Graphics g = Graphics.FromImage(resize))
            {
                g.DrawImage(signatureBitmap, 0, 0, size, size);
            }
            resize.MakeTransparent(Color.White);
            iTextSharp.text.Image signature = iTextSharp.text.Image.GetInstance(resize, ImageFormat.Png);
            signature.Alignment = Element.ALIGN_RIGHT;
            BaseFont baseFont = BaseFont.CreateFont("c:/windows/fonts/david.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            p.Font = new iTextSharp.text.Font(baseFont, 18);
            p.Alignment = Element.ALIGN_RIGHT;
            p.Add(Messages.Reverse("חתימה:"));
            p.Add(signature);

            return p;
        }
        public PdfPTable GetList()//create list of shoping cart in invoce PDF file
        {
            PdfPTable table = new PdfPTable(4);
            table.AddCell(getCell(GetElements( Messages.Reverse("מחיר")),"header"));
            table.AddCell(getCell(GetElements(Messages.Reverse("כמות")),"header")) ;
            table.AddCell(getCell(GetElements(Messages.Reverse("ליחידה מחיר")), "header"));
            table.AddCell(getCell(GetElements(Messages.Reverse("שם מוצר")), "header"));
            int total = 0;
            shopingCart = GetShopingCart();
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
        {//returning style of pdf files
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
        {//return sum of order
            return (int)GetColValue("total");
        }

        public Paragraph GetElements(string type)
        {//create the paragarf of pdf files
            Paragraph p = new Paragraph();
            BaseFont baseFont = BaseFont.CreateFont("c:/windows/fonts/david.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            string message;
            switch (type)
            {
                case "title":
                    p.Font = new iTextSharp.text.Font(baseFont, 40);
                    p.Alignment = Element.ALIGN_CENTER;
                    p.Add(Messages.Reverse($"קבלה מספר\n\n"));
                    p.Add($"{Value}");

                    return p;
                case "refund":
                    {
                        p.Font = new iTextSharp.text.Font(baseFont, 40);
                        p.Alignment = Element.ALIGN_CENTER;
                        p.Add(Messages.Reverse($"זיכוי מספר\n\n{Value}\n\n"));
                        return p;
                    }
                case "client":
                    p.Font = new iTextSharp.text.Font(baseFont, 20);
                    p.Alignment = Element.ALIGN_RIGHT;
                    p.Add(Messages.Reverse($"לקוח:\t{Person.GetName(GetColValue("client").ToString())}\nעובד:\t{Person.GetName(GetColValue("worker").ToString())}\n\n"));
                    return p;
                case "price":
                    {
                        p.Font = new iTextSharp.text.Font(baseFont, 20);
                        p.Alignment = Element.ALIGN_RIGHT;
                        p.Add(Messages.Reverse($"סכום של:\n"));
                        p.Add($"{GetTotal()}\n{Messages.Reverse("שקלים חדשים")}");
                        return p;
                    }
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

        private void SortCart()
        {//sorting shoping cart 
            List<Cart> SortedCart = new List<Cart>();
            foreach(Cart item in shopingCart)
            {
                if(!item.Product.IsTreatment())
                    SortedCart.Add(item);
                else
                {
                    for(int i = 0; i < item.GetAmount(); i++)
                    {
                        Cart c = new Cart();
                        c.SetAmount(1);
                        c.SetOrder_Id((int)Value);
                        c.SetProduct(item.GetProductId());
                        SortedCart.Add(c);
                    }
                }
            }
            shopingCart = SortedCart;
        }
        internal bool Save()
        {//saveing order in DB
            bool result = Update();
            if (result)
                result &= SaveCart();
            return result;
        }
        internal bool SaveCart()
        {//saveing shoping cart in DB
            SortCart();
            bool result= true;
            List<Products> products = new List<Products>();
            foreach (Cart c in shopingCart)
            {
                c.Table = Database_Names.Cart;
                if (Products.IsTreatment((int)c.GetColValue(Database_Names.Cart_Columes[2])) == false)
                {
                    Products p = Products.GetProduct((int)c.GetColValue(2));
                    p.SetColValue(0, (int)c.GetColValue(2));
                    p.ReduceInventory((int)c.GetColValue(3));
                    products.Add(p);
                    result &= c.Update();
                }
            }
            if (result)
                foreach (Products p in products)
                    p.Update();
            Products.Reload();
            return result;
        }

        internal string GetPurchaceDate()
        {
            return GetColValue(4).ToString();
        }

        internal string GetCartDate(Cart item)
        {
            throw new NotImplementedException();
        }

        internal string GetCartTime(Cart item)
        {
            throw new NotImplementedException();
        }

        internal List<Calender_Table> GetApooitments()
        {//returning all appoitment of order 
            List<Row> list = Access.getObjects(SQL_Queries.Select(Database_Names.Calendrer,new Condition(Database_Names.Calender_Columes[4],Value)));
            List<Calender_Table> appoitments = new List<Calender_Table>();
            if (list != null)
                foreach (Row row in list)
                {
                    appoitments.Add(new Calender_Table(row));
                }
            else
                return null;
            return appoitments;
        }

        internal List<Cart> GetShopingCart()
        {//returning shoping cart of order
            List<Row> list = Access.getObjects(SQL_Queries.Select(Database_Names.Cart, new Condition(Database_Names.Cart_Columes[1], (int)Value)));
            List<Cart> shopingcart = new List<Cart>();
            if (list != null)
                foreach (Row row in list)
                {
                    shopingcart.Add(new Cart(row));
                }
            else
                return null;
            return shopingcart;
        }

        internal bool IsPaid()
        {//returning if order was paid
            return (bool)GetColValue(Database_Names.Income_Columes[5]);
        }
        public static List<Income> GetIncomes(DateTime start, DateTime end)
        {//returning all order filter by dates
            List<Row> rows = Access.getObjects(SQL_Queries.Select(Database_Names.Income, Database_Names.Income_Columes[6], start, end));
            List<Income> list = new List<Income>();
            foreach(Row row in rows)
                list.Add(new Income(row));
            return list;

        }

        internal static List<Income> getIncomes(bool status)
        {//returning all order filter by status paid/unpaid
            List<Row> rows = Access.getObjects(SQL_Queries.Select(Database_Names.Income, new Condition(Database_Names.Income_Columes[5],status)));
            List<Income> list = new List<Income>();
            foreach (Row row in rows)
                list.Add(new Income(row));
            return list;
        }
        internal static List<Income> getIncomes(string id,bool paid)
        {//returning all order of client sorted by paid / not paid
            List<Condition> conditions = new List<Condition>() {
                 new Condition(Database_Names.Income_Columes[5], paid),
                 new Condition(Database_Names.Income_Columes[2],id)
            };
            List<Row> rows = Access.getObjects(SQL_Queries.Select(Database_Names.Income,conditions,"and"));
            List<Income> list = new List<Income>();
            foreach (Row row in rows)
                list.Add(new Income(row));
            return list;
        }
        public DateTime GetDate()
        {//returning purchae date of order
            return (DateTime)GetColValue(6);
        }
        internal bool BackUp()
        {//backup order in a diffrent DB
            return Access.Execute(SQL_Queries.Insert(Database_Names.Backup, Row.Columes));
        }
    }
}
