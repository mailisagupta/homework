// Class Exercise No. 1
// Rewrite TV Class, use properties instead of methods

class Television1
{
    private int channel = 0;
    private int volume = 0;
    private bool isOn = false;

    public bool On
    {
        get
        {
            return isOn;
        }
        set
        {
            isOn = value;
            if (isOn)
            {
                // do code here
                isOn = false;
            }
            else
            {
                isOn = true;
            }
        }
    }

    public int Volume
    {
        get
        {
            return volume;
        }
        set
        {
            if (value >= 0 && value <= 100)
            {
                // do the code to change the volume
                volume = value;
            }
        }
    }

    public int Channel
    {
        get
        {
            return channel;
        }
        set
        {
            if (value > 0 && value < 50)
            {
                // do the code to change the
                // channel on the tv
                channel = value;
            }
        }
    }
}

class pex1
{
    static void Main()
    {
        var tv = new Television1();

        if (tv.On == false)
        {
            tv.On = true;
        }

        tv.Channel = 3;

        tv.Volume++;
        tv.Volume++;
        tv.Volume++;
        tv.Volume++;

        tv.On = false;
    }
}