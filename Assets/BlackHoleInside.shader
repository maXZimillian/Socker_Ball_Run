Shader "Custom/BlackHoleInside"
{
    Properties{
    _MainTex("Particle Texture", 2D) = "white" {}
    }

        Category{
            Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "PreviewType" = "Plane" }
            ZTest Always
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off Lighting Off ZWrite Off Fog { Color(0,0,0,0) }

            BindChannels {
                Bind "Color", color
                Bind "Vertex", vertex
                Bind "TexCoord", texcoord
            }

            SubShader {
                Pass {
                    SetTexture[_MainTex] {
                        combine texture * primary
                    }
                }
            }
    }
}


