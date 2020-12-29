using System;
using Gtk;


public partial class MainWindow : Gtk.Window
{
                 //Variables Declrations

    //variables for fuel and vehicles
    int totalServices = 0;
    int usedFuel = 0;
    int fuelCapcity = 100;
    int vehiclesLeft = 0;

    // variables for commession
    double commission = 0.01;
    double timeinMinutes = 60;
    double timeinHours = 60;

    //variables for random time managemnt
    int totalTime = 0;
    int waitingTime = 0;
    int Vehicles = 0; //new vehicle created after certain time period
    int waitingPeriod = 30; //Time Period of vehicle wait in seconds



    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    private void ButtonClickme_Clicked(object sender, EventArgs args)
    {
        //Change the Button text at start
        Button theButton = (Button)button6;
        theButton.Label = "Next";

        //Time Periods and vehicles count

        waitingTime = totalTime + waitingPeriod;    // total wait time of vehicle
     
        int maxTime = 60;               //60 seconds
        Random rendTime = new Random();
        int timeValue = rendTime.Next(1, maxTime);

        totalTime = totalTime + timeValue;

        if (totalTime > waitingTime)        //condition if total time is greater than waiting time than vehicle will left
        {
            vehiclesLeft++;
            //Vehicles that left after 30seconds
            this.label12.Text = vehiclesLeft + "";
        }

        //Setting the incoming cars limit in pertol pump
        int macIncomingCars = 10;
        Random maxCar = new Random();
        int totalCars = maxCar.Next(1, macIncomingCars);

        Vehicles = Vehicles + totalCars-1;      // total vehicles and minus 1 becuse 1 vehicle just left as we pressed button


        //Random Numbers for Car Types

        int maxCars = 5;
        Random rndCar = new Random();
        int rndCars = rndCar.Next(1, maxCars);

        if (rndCars == 1)
        {
            this.label16.Text = "Car";
        }
        if (rndCars == 2)
        {
            this.label16.Text = "Truck";
        }
        if (rndCars == 3)
        {
            this.label16.Text = "Jeep";
        }
        if (rndCars == 4)
        {
            this.label16.Text = "Bike";
        }

        


        //Random Numbers for Fuel

        int maxFuel = 20;
        Random rndFuel = new Random();
        int randumNum = rndFuel.Next(1, maxFuel);


        int fuel = randumNum;
        int totalFuel = fuelCapcity - fuel;
        usedFuel = usedFuel + fuel;

        this.label17.Text = fuel + "";
        this.label8.Text = usedFuel + "";


        totalServices++;
        int total = usedFuel * 2;
        this.label6.Text = totalServices + "";
        this.label10.Text = total + "$";

        //commission total
        timeinMinutes = totalTime / 60;
        timeinHours = timeinMinutes / 60;
        
        commission = commission + 2.49 * timeinHours;

        this.label2.Text = commission + "$";


        //RandomNumbers for images aligned to pumps
        int maxpump = 10;
        Random rnd = new Random();
        int randnum = rnd.Next(1, maxpump);

        this.label18.Text = randnum + "";


        if (randnum == 1)
        {
            hideImage();
            image1.Show();
        }
        if (randnum == 2)
        {
            hideImage();
            image2.Show();
        }
        if (randnum == 3)
        {
            hideImage();
            image3.Show();
        }
        if (randnum == 4)
        {
            hideImage();
            image8.Show();
        }
        if (randnum == 5)
        {
            hideImage();
            image6.Show();
        }
        if (randnum == 6)
        {
            hideImage();
            image4.Show();
        }
        if (randnum == 7)
        {
            hideImage();
            image9.Show();
        }
        if (randnum == 8)
        {
            hideImage();
            image7.Show();
        }
        if (randnum == 9)
        {
            hideImage();
            image5.Show();
        }

        // Total fuel capcity and warning message for refill
        fuelCapcity = fuelCapcity - fuel;
        if (fuelCapcity < 0)
        {
            this.label20.Text = "Please Refill the Fuel";
            fuelCapcity = 100;

            MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Ok, "Please Refill the fuel!");
            md.Run();
            md.Destroy();
            this.label20.Text = fuelCapcity + "";

        }
        else
        {
            this.label20.Text = fuelCapcity + "";
        }

    }


    // images hide and show logic
    private void hideImage()
    {
        image1.Hide();
        image2.Hide();
        image3.Hide();
        image4.Hide();
        image5.Hide();
        image6.Hide();
        image7.Hide();
        image8.Hide();
        image9.Hide();
       
    }
}
