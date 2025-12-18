using UnityEngine;

public class GlyphsController
{
   
    
    public GlyphsController(){
          var manager = new AndroidJavaObject("com.nothing.glyph.GlyphManager");
          manager.Call("register","Glyph.DEVICE_23112");
          int[] iarr = {1,1,1,1,1,1,1,1,1};
          manager.Call("setMatrixFrame",iarr);
    }
    public void UpdateGlyph()
    {

    }
}
