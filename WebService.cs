using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    SqlCommand cmd;
    SqlDataAdapter da;
    SqlConnection con = new SqlConnection("Data Source=10.1.31.13;Initial Catalog=FPnew;User ID=sa;Password=Test@123");
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public DataTable[] getfpudata(string stcode, string sector)
    {
        try
        {
            DataTable[] dt = new DataTable[2];
            dt[0] = new DataTable(); dt[0].TableName = "india";
            dt[1] = new DataTable(); dt[1].TableName = "MIS";
            con.Open();
            string query = null; string temp = null;
            temp = @"sum([CONSUMER_INDUSTRIES]) as [CONSUMER_INDUSTRIES],
                              sum([DEEPSEA_FISHING_AND_FISH_PROCESSING]) as [DEEPSEA_FISHING_AND_FISH_PROCESSING]
	                         ,sum([FLOUR_MILLING]) as [FLOUR_MILLING]
	                         ,sum([FRUIT_AND_VEGETABLES]) as [FRUIT_AND_VEGETABLES]
	                         ,sum([MEAT_AND_POULTRY]) as [MEAT_AND_POULTRY]
	                         ,sum([MILK_AND_DAIRY_PRODUCTS]) as [MILK_AND_DAIRY_PRODUCTS]
	                         ,sum([OIL_MILLING]) as [OIL_MILLING]
                             ,sum([PULSE_MILLING]) as [PULSE_MILLING]
                             ,sum([RICE_MILLING]) as [RICE_MILLING]
                             ,sum([WINES_AND_BEER]) as [WINES_AND_BEER]";
            if (stcode == "all" && sector == "all")
            {
                query = @"SELECT [State_Code] as censuscode2011, State as StateName, " + temp + " FROM [Units Wise Report] group by [State_Code], State";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]); da.Fill(dt[1]);
            }
            else if (stcode != "all" && sector == "all")
            {
                query = @"SELECT [State_Code] as censuscode2011, State as StateName, " + temp + " FROM [Units Wise Report] group by [State_Code], State";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);

                query = @"SELECT [District_Code] as censuscode2011, District as DistrictName, " + temp + " FROM [Units Wise Report] where [State_Code] = '" + stcode + "' group by [District_Code], District";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[1]);
            }
            else if (stcode != "all" && sector != "all" && stcode.Length == 2)
            {
                query = @"SELECT * FROM [Full Data Sheet] where [State_Code]='" + stcode + "' and sector='" + sector + "'";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);

                query = @"SELECT * FROM [Full Data Sheet] where [State_Code]='" + stcode + "' and sector='" + sector + "'";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[1]);
            }
            else if (stcode != "all" && sector != "all" && stcode.Length == 3)
            {
                query = @"SELECT * FROM [Full Data Sheet] where [District_Code]='" + stcode + "' and sector='" + sector + "'";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);

                query = @"SELECT * FROM [Full Data Sheet] where [District_Code]='" + stcode + "' and sector='" + sector + "'";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[1]);
            }

            con.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    [WebMethod]
    public DataTable[] getfruitsdata(string stcode, string category)
    {
        try
        {
            DataTable[] dt = new DataTable[2];
            con.Open();
            string query = null;
            string temp = null;
            dt[0] = new DataTable(); dt[0].TableName = "india";
            dt[1] = new DataTable(); dt[1].TableName = "MIS";
            if (category == "fruits_production")
                temp = @"sum([Aonla_or_Gooseberry_Production]) as [Aonla_or_Gooseberry_Production]
      ,sum([Banana_Production]) as [Banana_Production]
      ,sum([Guava_Production]) as [Guava_Production]
      ,sum([Limes_and_Lemons_Production]) as [Limes_and_Lemons_Production]
      ,sum([Mango_Production]) as [Mango_Production]
      ,sum([Papaya_Production]) as [Papaya_Production]
      ,sum([Pomegranate_Production]) as [Pomegranate_Production]
      ,sum([Sapota_Production]) as [Sapota_Production]
      ,sum([Sweet_Orange_or_Mosambi_Production]) as [Sweet_Orange_or_Mosambi_Production]
      ,sum([Watermelon_Production]) as [Watermelon_Production]
      ,sum([Jackfruit_Production]) as [Jackfruit_Production]
      ,sum([Kinnow_or_Mandarin_Orange_Production]) as [Kinnow_or_Mandarin_Orange_Production]
      ,sum([Litchi_Production]) as [Litchi_Production]
      ,sum([Pineapple_Production]) as [Pineapple_Production]
      ,sum([Ber_Production]) as [Ber_Production]
      ,sum([Custard_Apple_Production]) as [Custard_Apple_Production]
      ,sum([Apple_Production]) as [Apple_Production]
      ,sum([Apricot_Production]) as [Apricot_Production]
      ,sum([Peach_Production]) as [Peach_Production]
      ,sum([Pear_Production]) as [Pear_Production]
      ,sum([Plum_Production]) as [Plum_Production]
      ,sum([Walnut_Production]) as [Walnut_Production]
      ,sum([Muskmelon_Production]) as [Muskmelon_Production]
      ,sum([Other_Citrus_Production]) as [Other_Citrus_Production]
      ,sum([Other_Fruits_Production]) as [Other_Fruits_Production]
      ,sum([Almond_Production]) as [Almond_Production]
      ,sum([Cherry_Production]) as [Cherry_Production]
      ,sum([Grape_Production]) as [Grape_Production]
      ,sum([Bael_Production]) as [Bael_Production]
,sum([All_fruits_Production]) as [All_fruits_Production]
,sum([Passion_Fruit_Production]) as [Passion_Fruit_Production]
,sum([Strawberry_Production]) as [Strawberry_Production]
,sum([Kiwi_Production]) as [Kiwi_Production]";
            else if (category == "fruits_area")
                temp = @"sum([Aonla_or_Gooseberry_Area]) as [Aonla_or_Gooseberry_Area]
      , sum([Banana_Area]) as [Banana_Area]
      , sum([Guava_Area]) as [Guava_Area]
      , sum([Limes_and_Lemons_Area]) as [Limes_and_Lemons_Area]
      , sum([Mango_Area]) as [Mango_Area]
      , sum([Papaya_Area]) as [Papaya_Area]
      , sum([Pomegranate_Area]) as [Pomegranate_Area]
      , sum([Sapota_Area]) as [Sapota_Area]
      , sum([Sweet_Orange_or_Mosambi_Area]) as [Sweet_Orange_or_Mosambi_Area]
      , sum([Watermelon_Area]) as [Watermelon_Area]
      , sum([Jackfruit_Area]) as [Jackfruit_Area]
      , sum([Kinnow_or_Mandarin_Orange_Area]) as [Kinnow_or_Mandarin_Orange_Area]
      , sum([Litchi_Area]) as [Litchi_Area]
      , sum([Pineapple_Area]) as [Pineapple_Area]
      , sum([Ber_Area]) as [Ber_Area]
      , sum([Custard_Apple_Area]) as [Custard_Apple_Area]
      , sum([Apple_Area]) as [Apple_Area]
      , sum([Apricot_Area]) as [Apricot_Area]
      , sum([Peach_Area]) as [Peach_Area]
      , sum([Pear_Area]) as [Pear_Area]
      , sum([Plum_Area]) as [Plum_Area]
      , sum([Walnut_Area]) as [Walnut_Area]
      , sum([Muskmelon_Area]) as [Muskmelon_Area]
      , sum([Other_Citrus_Area]) as [Other_Citrus_Area]
      , sum([Other_Fruits_Area]) as [Other_Fruits_Area]
      , sum([Almond_Area]) as [Almond_Area]
      , sum([Cherry_Area]) as [Cherry_Area]
      , sum([Grape_Area]) as [Grape_Area]
      , sum([Bael_Area]) as [Bael_Area]
      , sum([All_fruits_Area]) as [All_fruits_Area]
, sum([Passion_Fruit_Area]) as [Passion_Fruit_Area]
      , sum([Strawberry_Area]) as [Strawberry_Area]
      , sum([Kiwi_Area]) as [Kiwi_Area]";
            if (stcode == "all")
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [Fruits1] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);
                da.Fill(dt[1]);
            }
            else if (stcode != "all" && stcode.Length == 2)
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [Fruits1] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);

                query = @"SELECT district_code as censuscode2011, District as DistrictName, " + temp + " FROM [Fruits1] where state_code = '" + stcode + "' group by District_code, District";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[1]);
            }
            else if (stcode != "all" && stcode.Length == 3)
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [Fruits1] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);

                query = @"SELECT district_code as censuscode2011, District as DistrictName, " + temp + " FROM [Fruits1] where District_code = '" + stcode + "' group by District_code, District";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[1]);
            }
            con.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    [WebMethod]
    public DataTable[] getvegetablesdata(string stcode, string category)
    {
        try
        {
            DataTable[] dt = new DataTable[2];
            con.Open();
            string query = null;
            string temp = null;
            dt[0] = new DataTable(); dt[0].TableName = "india";
            dt[1] = new DataTable(); dt[1].TableName = "MIS";
            if (category == "vegetables_production")
                temp = @"sum([Arbi_or_Colacasia_Production]) as  [Arbi_or_Colacasia_Production]
      ,sum([Ash_Gourd_or_Petha_Production]) as  [Ash_Gourd_or_Petha_Production]
      ,sum([Beans_Production]) as  [Beans_Production]
      ,sum([Bitter_Gourd_Production]) as  [Bitter_Gourd_Production]
      ,sum([Beetroot_Production]) as  [Beetroot_Production]
      ,sum([Bottle_Gourd_Production]) as  [Bottle_Gourd_Production]
      ,sum([Brinjal_Production]) as  [Brinjal_Production]
      ,sum([Cabbage_Production]) as  [Cabbage_Production]
      ,sum([Carrot_Production]) as  [Carrot_Production]
      ,sum([Cauliflower_Production]) as  [Cauliflower_Production]
      ,sum([Capsicum_Production]) as  [Capsicum_Production]
      ,sum([Cucumber_Production]) as  [Cucumber_Production]
      ,sum([Elephant_Foot_Yam_or_Amorphophallus_or_Jimikand_Production]) as  [Elephant_Foot_Yam_or_Amorphophallus_or_Jimikand_Production]
      ,sum([Green_Chilli_Production]) as  [Green_Chilli_Production]
      ,sum([Kaddu_or_Pumpkin_Production]) as  [Kaddu_or_Pumpkin_Production]
      ,sum([Leafy_Vegetables(Amaranthus,Kashmiri Sag,Spinach,Celery etc#)_Pr]) as [Leafy_Vegetables_Amaranthus_Kashmiri_Sag_Spinach_Celery_etc_Pr]
      ,sum([Mushroom_Production]) as [Mushroom_Production]
      ,sum([Okra_or_Ladies_Finger_Production]) as  [Okra_or_Ladies_Finger_Production]
      ,sum([Onion_Production]) as  [Onion_Production]
      ,sum([Peas_(Green)_Production]) as  [Peas_Green_Production]
      ,sum([Pointed_Gourd_or_Parwal_Production]) as  [Pointed_Gourd_or_Parwal_Production]
      ,sum([Potato_Production]) as  [Potato_Production]
      ,sum([Radish_Production]) as  [Radish_Production]
      ,sum([Ridge_or_Sponge_Gourd(Torai)_Production]) as  [Ridge_or_Sponge_Gourd_Torai_Production]
      ,sum([Sweet Potato_Production]) as  [Sweet_Potato_Production]
      ,sum([Tapioca_Production]) as  [Tapioca_Production]
      ,sum([Tomato_Production]) as  [Tomato_Production]
      ,sum([Turnip_Production]) as  [Turnip_Production]
	  ,sum([All_veg_Production]) as  [All_veg_Production]";
            else if (category == "vegetables_area")
                temp = @"sum([Arbi_or_Colacasia_Area]) as [Arbi_or_Colacasia_Area]
      ,sum([Ash_Gourd_or_Petha_Area]) as [Ash_Gourd_or_Petha_Area]
      ,sum([Beans_Area]) as [Beans_Area]
      ,sum([Bitter_Gourd_Area]) as [Bitter_Gourd_Area]
      ,sum([Beetroot_Area]) as [Beetroot_Area]
      ,sum([Bottle_Gourd_Area]) as [Bottle_Gourd_Area]
      ,sum([Cabbage_Area]) as [Cabbage_Area]
      ,sum([Brinjal_Area]) as [Brinjal_Area]
      ,sum([Carrot_Area]) as [Carrot_Area]
      ,sum([Cauliflower_Area]) as [Cauliflower_Area]
      ,sum([Capsicum_Area]) as [Capsicum_Area]
      ,sum([Cucumber_Area]) as [Cucumber_Area]
      ,sum([Elephant_Foot_Yam_or_Amorphophallus_or_Jimikand_Area]) as [Elephant_Foot_Yam_or_Amorphophallus_or_Jimikand_Area]
      ,sum([Green_Chilli_Area]) as [Green_Chilli_Area]
      ,sum([Kaddu_or_Pumpkin_Area]) as [Kaddu_or_Pumpkin_Area]
      ,sum([Leafy_Vegetables(Amaranthus,Kashmiri Sag,Spinach,Celery etc#)_Ar]) as [Leafy_Vegetables_Amaranthus_Kashmiri_Sag_Spinach_Celery_etc_Ar]
      ,sum([Mushroom_Area]) as [Mushroom_Area]
      ,sum([Okra_or_Ladies_Finger_Area]) as [Okra_or_Ladies_Finger_Area]
      ,sum([Onion_Area]) as [Onion_Area]
      ,sum([Peas_(Green)_Area]) as [Peas_Green_Area]
      ,sum([Pointed_Gourd_or_Parwal_Area]) as [Pointed_Gourd_or_Parwal_Area]
      ,sum([Potato_Area]) as [Potato_Area]
      ,sum([Radish_Area]) as [Radish_Area]
      ,sum([Ridge_or_Sponge_Gourd (Torai)_Area]) as [Ridge_or_Sponge_Gourd_Torai_Area]
      ,sum([Sweet_Potato_Area]) as [Sweet_Potato_Area]
      ,sum([Tapioca_Area]) as [Tapioca_Area]
      ,sum([Tomato_Area]) as [Tomato_Area]
      ,sum([Turnip_Area]) as [Turnip_Area]
      ,sum([All_veg_Area]) as  [All_veg_Area]";
            if (stcode == "all")
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [Vegetables1] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);
                da.Fill(dt[1]);
            }
            else if (stcode != "all" && stcode.Length==2)
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [Vegetables1] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);

                query = @"SELECT district_code as censuscode2011, District as DistrictName, " + temp + " FROM [Vegetables1] where state_code = '" + stcode + "' group by District_code, District";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[1]);
            }
            else if (stcode != "all" && stcode.Length == 3)
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [Vegetables1] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);

                query = @"SELECT district_code as censuscode2011, District as DistrictName, " + temp + " FROM [Vegetables1] where district_code = '" + stcode + "' group by District_code, District";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[1]);
            }
            con.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    [WebMethod]
    public DataTable[] getspicesdata(string stcode, string category)
    {
        try
        {
            DataTable[] dt = new DataTable[2];
            con.Open();
            string query = null;
            string temp = null;
            dt[0] = new DataTable(); dt[0].TableName = "india";
            dt[1] = new DataTable(); dt[1].TableName = "MIS";
            if (category == "spices_production")
                temp = @"sum([Ajwain_or_Carom_Production]) as [Ajwain_or_Carom_Production]
      ,sum([Betelvine_Production]) as [Betelvine_Production]
      ,sum([Black_Pepper_Production]) as [Black_Pepper_Production]
      ,sum([Cardamom_Large_Production]) as [Cardamom_Large_Production]
      ,sum([Cardamom_Small_Production]) as [Cardamom_Small_Production]
      ,sum([Cinnamon_Production]) as [Cinnamon_Production]
      ,sum([Clove_Production]) as [Clove_Production]
      ,sum([Coriander_Seed_Production]) as [Coriander_Seed_Production]
      ,sum([Cumin_Production]) as [Cumin_Production]
      ,sum([Fennel_Production]) as [Fennel_Production]
      ,sum([Fenugreek_Production]) as [Fenugreek_Production]
      ,sum([Garlic_Production]) as [Garlic_Production]
      ,sum([Ginger_Production]) as [Ginger_Production]
      ,sum([Mint_Production]) as [Mint_Production]
      ,sum([Nutmeg_Production]) as [Nutmeg_Production]
      ,sum([Celery_or_Dill_Seeds_or_Poppy_Production]) as [Celery_or_Dill_Seeds_or_Poppy_Production]
      ,sum([Red_Chilly_Production]) as [Red_Chilly_Production]
      ,sum([Tamarind_Production]) as [Tamarind_Production]
      ,sum([Turmeric_Production]) as [Turmeric_Production]
      ,sum([Vanilla_Production]) as [Vanilla_Production]
      ,sum([Saffron_Production]) as [Saffron_Production]
      ,sum([Other_Spices_Production]) as [Other_Spices_Production]
	  ,sum([All_spices_Production]) as [All_spices_Production]";
            else if (category == "spices_area")
                temp = @"sum([Ajwain_or_Carom_Area]) as [Ajwain_or_Carom_Area]
      ,sum([Betelvine_Area]) as [Betelvine_Area]
      ,sum([Black_Pepper_Area]) as [Black_Pepper_Area]
      ,sum([Cardamom_Large_Area]) as [Cardamom_Large_Area]
      ,sum([Cardamom_Small_Area]) as [Cardamom_Small_Area]
      ,sum([Cinnamon_Area]) as [Cinnamon_Area]
      ,sum([Clove_Area]) as [Clove_Area]
      ,sum([Coriander_Seed_Area]) as [Coriander_Seed_Area]
      ,sum([Cumin_Area]) as [Cumin_Area]
      ,sum([Fennel_Area]) as [Fennel_Area]
      ,sum([Fenugreek_Area]) as [Fenugreek_Area]
      ,sum([Garlic_Area]) as [Garlic_Area]
      ,sum([Ginger_Area]) as [Ginger_Area]
      ,sum([Mint_Area]) as [Mint_Area]
      ,sum([Nutmeg_Area]) as [Nutmeg_Area]
      ,sum([Celery_or_Dill_Seeds_or_Poppy_Area]) as [Celery_or_Dill_Seeds_or_Poppy_Area]
      ,sum([Red_Chilly_Area]) as [Red_Chilly_Area]
      ,sum([Tamarind_Area]) as [Tamarind_Area]
      ,sum([Turmeric_Area]) as [Turmeric_Area]
      ,sum([Vanilla_Area]) as [Vanilla_Area]
      ,sum([Saffron_Area]) as [Saffron_Area]
      ,sum([Other_Spices_Area]) as [Other_Spices_Area],sum([All_spices_Area]) as [All_spices_Area]";
            if (stcode == "all")
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [spices] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);
                da.Fill(dt[1]);
            }
            else if (stcode != "all" && stcode.Length==2)
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [spices] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);

                //query = @"SELECT district_code as censuscode2011, District as DistrictName, " + temp + " FROM [spices] where state_code = '" + stcode + "' group by District_code, District";
                //da = new SqlDataAdapter(query, con);
                //da.Fill(dt[1]);
            }
            else if (stcode != "all" && stcode.Length == 3)
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [spices] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);

                query = @"SELECT district_code as censuscode2011, District as DistrictName, " + temp + " FROM [spices] where district_code = '" + stcode + "' group by District_code, District";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[1]);
            }
            con.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    [WebMethod]
    public DataTable[] gethorticulturedata(string stcode, string category)
    {
        try
        {
            DataTable[] dt = new DataTable[2];
            con.Open();
            string query = null;
            string temp = null;
            dt[0] = new DataTable(); dt[0].TableName = "india";
            dt[1] = new DataTable(); dt[1].TableName = "MIS";
            if (category == "horticulture_production")
                temp = @"sum([horticulture_production]) as [horticulture_production],
                         sum([All_fruits_Production]) as [fruits_production],
sum([All_veg_Production]) as [vegetables_production]
                        ";
            else if (category == "horticulture_area")
                temp = @"sum([horticulture_area]) as [horticulture_area],
                         sum([All_fruits_Area]) as [fruits_area],
sum([All_veg_area]) as [vegetables_area]";
            if (stcode == "all")
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [horticulture] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);
                da.Fill(dt[1]);
            }
            else if (stcode != "all" && stcode.Length==2)
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [horticulture] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);

                query = @"SELECT district_code as censuscode2011, District as DistrictName, " + temp + " FROM [horticulture] where state_code = '" + stcode + "' group by District_code, District";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[1]);
            }
            else if (stcode != "all" && stcode.Length == 3)
            {
                query = @"SELECT [State_code] as censuscode2011, ([State]) as StateName, " + temp + " FROM [horticulture] group by [State_code],[State]";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[0]);

                query = @"SELECT district_code as censuscode2011, District as DistrictName, " + temp + " FROM [horticulture] where district_code = '" + stcode + "' group by District_code, District";
                da = new SqlDataAdapter(query, con);
                da.Fill(dt[1]);
            }
            con.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    [WebMethod]
    public DataTable gettop10districtsdata(string category, string subcategory)
    {
        try
        {
            string temp = null;
            if (category == "horticulture_production")
                temp = @"sum([horticulture_production]) as [horticulture_production],
                         sum([All_fruits_Production]) as [fruits_production],
sum([All_veg_Production]) as [vegetables_production]
                        ";
            else if (category == "horticulture_area")
                temp = @"sum([horticulture_area]) as [horticulture_area],
                         sum([All_fruits_Area]) as [fruits_area],
sum([All_veg_area]) as [vegetables_area]";
            else temp = @"sum([" + subcategory + "]) as ["+subcategory+"]";

            if (category == "horticulture_production" || category == "horticulture_area")
                category = "horticulture";
            else if (category == "fruits_production" || category == "fruits_area")
                category="Fruits1";
            else if (category == "vegetables_production" || category == "vegetables_area")
                category = "Vegetables1";
            else if (category == "spices_production" || category == "spices_area")
                category = "spices";
            else if (category == "Food_Processing_Units")
                category = "[Units Wise Report]";
            DataTable dt = new DataTable();
            con.Open();
            string query = null;
            dt.TableName = "MIS";

            query = @"SELECT top 10 district_code as censuscode2011, District as DistrictName,"+temp + " FROM " + category + " group by District_code, District order by " + subcategory + " desc";
            da = new SqlDataAdapter(query, con);
            da.Fill(dt);

            con.Close();
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
