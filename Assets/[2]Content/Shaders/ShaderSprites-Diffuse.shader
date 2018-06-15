
Shader "Homebrew/Sprites/Diffuse"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
      
        _MaskColor ("Mask color", Color) = (1, 1, 0, 1)
        [HDR]_ReplaceColor ("Replace color", Color) = (1, 1, 1, 1)
         _Threshold ("Threshold", Range(0, 1)) = 0
         
  
         
         
         _BlinkColor ("Blink color", Color) = (1, 1, 1, 1)   
         [Toggle]_Blink ("IsBlinking", Float) = 0
         _BlinkColorAlt ("Blink color alt", Color) = (1, 1, 1, 1)   
         [Toggle]_BlinkAlt ("IsBlinkingAlt", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert nofog nolightmap nodynlightmap keepalpha noinstancing
        #pragma multi_compile _ PIXELSNAP_ON
        #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
        #include "UnitySprites.cginc"

            
	    
            fixed4 _MaskColor;
            fixed4 _ReplaceColor;
  
            fixed4 _BlinkColor;
            fixed4 _BlinkColorAlt;
            fixed _Threshold;
     
    
            fixed _Blink;
            fixed _BlinkAlt;
            
        struct Input
        {
            float2 uv_MainTex;
            fixed4 color;
        };
 
        void vert (inout appdata_full v, out Input o)
        {
            v.vertex.xy *= _Flip.xy;

            #if defined(PIXELSNAP_ON)
            v.vertex = UnityPixelSnap (v.vertex);
            #endif

            UNITY_INITIALIZE_OUTPUT(Input, o);
             o.color =  v.color  * _Color * _RendererColor;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = SampleSpriteTexture (IN.uv_MainTex) * IN.color;
            
          
              fixed3 diff = c.rgb - _MaskColor.rgb;
               
              c.rgb = dot(diff, diff) < _Threshold ? _ReplaceColor.rgb : c.rgb;
        
              o.Albedo = c.rgb * c.a;
              o.Alpha = c.a;
              
               o.Emission = _Blink*c.a*_BlinkColor;
              
               
               o.Emission = _BlinkAlt==1 ? c.a*_BlinkColorAlt : _Blink*c.a*_BlinkColor;
                                            
      
        }
        ENDCG
    }

Fallback "Transparent/VertexLit"
}
