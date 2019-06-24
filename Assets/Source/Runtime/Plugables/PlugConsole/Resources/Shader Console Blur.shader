Shader "Utils/Blur"
{
    Properties
    {
          [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Radius("Radius", Range(0, 255)) = 0
        _Color ("Tint", Color) = (1,1,1,1)
        
        _ColorMask ("Color Mask", Float) = 15
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        
    }

    Category
    {
          Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }
 

        SubShader
        {
            GrabPass
            {
                Tags{ "LightMode" = "Always" }
            }

            Pass
            {
                Tags{ "LightMode" = "Always" }

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma fragmentoption ARB_precision_hint_fastest
                #include "UnityCG.cginc"

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 texcoord: TEXCOORD0;
    
                float4 color    : COLOR;
              
                    
                };

                struct v2f
                {
                    float4 vertex : POSITION;
                    float4 uvgrab : TEXCOORD0;
                      fixed4 color    : COLOR;
                };

                fixed4 _Color;
                sampler2D _GrabTexture;
                sampler2D _MainTex;
                float4 _GrabTexture_TexelSize;
                float _Radius;
                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    #if UNITY_UV_STARTS_AT_TOP
                    float scale = -1.0;
                    #else
                    float scale = 1.0;
                    #endif
                    o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
                    o.uvgrab.zw = o.vertex.zw;
                    o.color = v.color * _Color;
                    return o;
                }

          
             half4 frag(v2f i) : SV_Target
                {
                    half4 sum =   half4(0,0,0,0);
                 half4 color = (tex2D(_MainTex, i.uvgrab)) * i.color;
                    #define GRABXYPIXEL(kernelx, kernely) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x + _GrabTexture_TexelSize.x * kernelx, i.uvgrab.y + _GrabTexture_TexelSize.y * kernely, i.uvgrab.z, i.uvgrab.w)))
   float radius = 1.41421356237 * _Radius;
                    sum += GRABXYPIXEL(0.0, 0.0);
                    int measurments = 1;

            
                    for (float range = 1.41421356237f; range <= radius * 1.41; range += 1.41421356237f)
                    {
                        if (color.a>0){
                        sum += GRABXYPIXEL(range, range);
                        sum += GRABXYPIXEL(range, -range);
                        sum += GRABXYPIXEL(-range, range);
                        sum += GRABXYPIXEL(-range, -range);
                             
                                measurments += 4;
                        }
                
                    }

                    return sum / measurments;
                }
 
                ENDCG
                
                }
                
                 GrabPass
            {
                Tags{ "LightMode" = "Always" }
            }

            Pass
            {
                Tags{ "LightMode" = "Always" }

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma fragmentoption ARB_precision_hint_fastest
                #include "UnityCG.cginc"

                fixed4 _Color;
                sampler2D _GrabTexture;
                sampler2D _MainTex;
                float4 _GrabTexture_TexelSize;
                float _Radius;
              
                      struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 texcoord: TEXCOORD0;
    
                float4 color    : COLOR;
              
                    
                };

                struct v2f
                {
                    float4 vertex : POSITION;
                    float4 uvgrab : TEXCOORD0;
                      fixed4 color    : COLOR;
                };

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    #if UNITY_UV_STARTS_AT_TOP
                    float scale = -1.0;
                    #else
                    float scale = 1.0;
                    #endif
                    o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
                    o.uvgrab.zw = o.vertex.zw;
                      o.color = v.color * _Color;
                    return o;
                }

          

                half4 frag(v2f i) : SV_Target
                {

                    half4 sum = half4(0,0,0,0);
                    float radius = 1.41421356237 * _Radius;
                    half4 color = (tex2D(_MainTex, i.uvgrab)) * i.color;
                    #define GRABXYPIXEL(kernelx, kernely) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(i.uvgrab.x + _GrabTexture_TexelSize.x * kernelx, i.uvgrab.y + _GrabTexture_TexelSize.y * kernely, i.uvgrab.z, i.uvgrab.w)))

                    sum += GRABXYPIXEL(0.0, 0.0);
                    int measurments = 1;

                    for (float range = 1.41421356237f; range <= radius * 1.41; range += 1.41421356237f)
                    {
                           if (color.a>0){
                        sum += GRABXYPIXEL(range, 0);
                        sum += GRABXYPIXEL(-range, 0);
                        sum += GRABXYPIXEL(0, range);
                        sum += GRABXYPIXEL(0, -range);
                        measurments += 4;
                      }
                    }

                    return sum / measurments;
                }
                ENDCG
                
            }
            
        }
          
    }
}
