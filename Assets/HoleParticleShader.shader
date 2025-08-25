Shader "Hidden/HoleParticleShader" {
        Properties{
         _MainTex("Particle Texture", 2D) = "white" { }
        }
        SubShader{
             Tags { "QUEUE" = "Transparent" "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" "PreviewType" = "Plane" }
             Pass {
              Tags { "QUEUE" = "Transparent" "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" "PreviewType" = "Plane" }
              ZWrite Off
              Cull Off
              Blend SrcAlpha OneMinusSrcAlpha
            //////////////////////////////////
            //                              //
            //      Compiled programs       //
            //                              //
            //////////////////////////////////
          //////////////////////////////////////////////////////
          Global Keywords : <none>
          Local Keywords : <none>
          --Hardware tier variant : Tier 1
          --Vertex shader for "gles3" :
          Set 2D Texture "_MainTex" to slot 0

          Constant Buffer "$Globals" (48 bytes) {
            Vector4 unity_ObjectToWorld at 0
            Vector4 unity_MatrixVP at 16
            Vector4 _MainTex_ST at 32
          }

          Shader Disassembly :
          #ifdef VERTEX
          #version 300 es

          #define HLSLCC_ENABLE_UNIFORM_BUFFERS 1
          #if HLSLCC_ENABLE_UNIFORM_BUFFERS
          #define UNITY_UNIFORM
          #else
          #define UNITY_UNIFORM uniform
          #endif
          #define UNITY_SUPPORTS_UNIFORM_LOCATION 1
          #if UNITY_SUPPORTS_UNIFORM_LOCATION
          #define UNITY_LOCATION(x) layout(location = x)
          #define UNITY_BINDING(x) layout(binding = x, std140)
          #else
          #define UNITY_LOCATION(x)
          #define UNITY_BINDING(x) layout(std140)
          #endif
          uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
          uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
          uniform 	vec4 _MainTex_ST;
          in highp vec3 in_POSITION0;
          in mediump vec4 in_COLOR0;
          in highp vec3 in_TEXCOORD0;
          out mediump vec4 vs_COLOR0;
          out highp vec2 vs_TEXCOORD0;
          vec4 u_xlat0;
          vec4 u_xlat1;
          void main()
          {
              vs_COLOR0 = in_COLOR0;
          #ifdef UNITY_ADRENO_ES3
              vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
          #else
              vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
          #endif
              vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
              u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
              u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
              u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
              gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
              return;
          }

          #endif
          #ifdef FRAGMENT
          #version 300 es

          precision highp float;
          precision highp int;
          #define UNITY_SUPPORTS_UNIFORM_LOCATION 1
          #if UNITY_SUPPORTS_UNIFORM_LOCATION
          #define UNITY_LOCATION(x) layout(location = x)
          #define UNITY_BINDING(x) layout(binding = x, std140)
          #else
          #define UNITY_LOCATION(x)
          #define UNITY_BINDING(x) layout(std140)
          #endif
          UNITY_LOCATION(0) uniform mediump sampler2D _MainTex;
          in mediump vec4 vs_COLOR0;
          in highp vec2 vs_TEXCOORD0;
          layout(location = 0) out mediump vec4 SV_Target0;
          mediump vec4 u_xlat16_0;
          void main()
          {
              u_xlat16_0 = texture(_MainTex, vs_TEXCOORD0.xy);
              SV_Target0 = u_xlat16_0 * vs_COLOR0;
              return;
          }

          #endif


          //////////////////////////////////////////////////////
          Global Keywords : <none>
          Local Keywords : <none>
          --Hardware tier variant : Tier 2
          --Vertex shader for "gles3" :
          Set 2D Texture "_MainTex" to slot 0

          Constant Buffer "$Globals" (48 bytes) {
            Vector4 unity_ObjectToWorld at 0
            Vector4 unity_MatrixVP at 16
            Vector4 _MainTex_ST at 32
          }

          Shader Disassembly :
          #ifdef VERTEX
          #version 300 es

          #define HLSLCC_ENABLE_UNIFORM_BUFFERS 1
          #if HLSLCC_ENABLE_UNIFORM_BUFFERS
          #define UNITY_UNIFORM
          #else
          #define UNITY_UNIFORM uniform
          #endif
          #define UNITY_SUPPORTS_UNIFORM_LOCATION 1
          #if UNITY_SUPPORTS_UNIFORM_LOCATION
          #define UNITY_LOCATION(x) layout(location = x)
          #define UNITY_BINDING(x) layout(binding = x, std140)
          #else
          #define UNITY_LOCATION(x)
          #define UNITY_BINDING(x) layout(std140)
          #endif
          uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
          uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
          uniform 	vec4 _MainTex_ST;
          in highp vec3 in_POSITION0;
          in mediump vec4 in_COLOR0;
          in highp vec3 in_TEXCOORD0;
          out mediump vec4 vs_COLOR0;
          out highp vec2 vs_TEXCOORD0;
          vec4 u_xlat0;
          vec4 u_xlat1;
          void main()
          {
              vs_COLOR0 = in_COLOR0;
          #ifdef UNITY_ADRENO_ES3
              vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
          #else
              vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
          #endif
              vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
              u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
              u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
              u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
              gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
              return;
          }

          #endif
          #ifdef FRAGMENT
          #version 300 es

          precision highp float;
          precision highp int;
          #define UNITY_SUPPORTS_UNIFORM_LOCATION 1
          #if UNITY_SUPPORTS_UNIFORM_LOCATION
          #define UNITY_LOCATION(x) layout(location = x)
          #define UNITY_BINDING(x) layout(binding = x, std140)
          #else
          #define UNITY_LOCATION(x)
          #define UNITY_BINDING(x) layout(std140)
          #endif
          UNITY_LOCATION(0) uniform mediump sampler2D _MainTex;
          in mediump vec4 vs_COLOR0;
          in highp vec2 vs_TEXCOORD0;
          layout(location = 0) out mediump vec4 SV_Target0;
          mediump vec4 u_xlat16_0;
          void main()
          {
              u_xlat16_0 = texture(_MainTex, vs_TEXCOORD0.xy);
              SV_Target0 = u_xlat16_0 * vs_COLOR0;
              return;
          }

          #endif


          //////////////////////////////////////////////////////
          Global Keywords : <none>
          Local Keywords : <none>
          --Hardware tier variant : Tier 3
          --Vertex shader for "gles3" :
          Set 2D Texture "_MainTex" to slot 0

          Constant Buffer "$Globals" (48 bytes) {
            Vector4 unity_ObjectToWorld at 0
            Vector4 unity_MatrixVP at 16
            Vector4 _MainTex_ST at 32
          }

          Shader Disassembly :
          #ifdef VERTEX
          #version 300 es

          #define HLSLCC_ENABLE_UNIFORM_BUFFERS 1
          #if HLSLCC_ENABLE_UNIFORM_BUFFERS
          #define UNITY_UNIFORM
          #else
          #define UNITY_UNIFORM uniform
          #endif
          #define UNITY_SUPPORTS_UNIFORM_LOCATION 1
          #if UNITY_SUPPORTS_UNIFORM_LOCATION
          #define UNITY_LOCATION(x) layout(location = x)
          #define UNITY_BINDING(x) layout(binding = x, std140)
          #else
          #define UNITY_LOCATION(x)
          #define UNITY_BINDING(x) layout(std140)
          #endif
          uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
          uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
          uniform 	vec4 _MainTex_ST;
          in highp vec3 in_POSITION0;
          in mediump vec4 in_COLOR0;
          in highp vec3 in_TEXCOORD0;
          out mediump vec4 vs_COLOR0;
          out highp vec2 vs_TEXCOORD0;
          vec4 u_xlat0;
          vec4 u_xlat1;
          void main()
          {
              vs_COLOR0 = in_COLOR0;
          #ifdef UNITY_ADRENO_ES3
              vs_COLOR0 = min(max(vs_COLOR0, 0.0), 1.0);
          #else
              vs_COLOR0 = clamp(vs_COLOR0, 0.0, 1.0);
          #endif
              vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
              u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
              u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
              u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
              u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
              u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
              gl_Position = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
              return;
          }

          #endif
          #ifdef FRAGMENT
          #version 300 es

          precision highp float;
          precision highp int;
          #define UNITY_SUPPORTS_UNIFORM_LOCATION 1
          #if UNITY_SUPPORTS_UNIFORM_LOCATION
          #define UNITY_LOCATION(x) layout(location = x)
          #define UNITY_BINDING(x) layout(binding = x, std140)
          #else
          #define UNITY_LOCATION(x)
          #define UNITY_BINDING(x) layout(std140)
          #endif
          UNITY_LOCATION(0) uniform mediump sampler2D _MainTex;
          in mediump vec4 vs_COLOR0;
          in highp vec2 vs_TEXCOORD0;
          layout(location = 0) out mediump vec4 SV_Target0;
          mediump vec4 u_xlat16_0;
          void main()
          {
              u_xlat16_0 = texture(_MainTex, vs_TEXCOORD0.xy);
              SV_Target0 = u_xlat16_0 * vs_COLOR0;
              return;
          }

          #endif


          //////////////////////////////////////////////////////
          Global Keywords : <none>
          Local Keywords : <none>
          --Hardware tier variant : Tier 1
          --Vertex shader for "vulkan" :
          Uses vertex data channel "Color"
          Uses vertex data channel "TexCoord0"
          Uses vertex data channel "Vertex"

          Set 2D Texture "_MainTex" to set : 0, binding : 1, used in : Fragment  using sampler in set : 0, binding : 0, used in : Fragment

          Constant Buffer "VGlobals2998864059" (144 bytes) on set : 1, binding : 0, used in : Vertex  {
            Matrix4x4 unity_MatrixVP at 64
            Matrix4x4 unity_ObjectToWorld at 0
            Vector4 _MainTex_ST at 128
          }

          Shader Disassembly :
          Disassembly for Vertex :
              // Module Version 10000
              // Generated by (magic number): 80006
              // Id's are bound by 125

                                            Capability Shader
                             1:             ExtInstImport  "GLSL.std.450"
                                            MemoryModel Logical GLSL450
                                            EntryPoint Vertex 4  "main" 9 11 21 24 47 98
                                            Name 21  "vs_TEXCOORD0"
                                            Decorate 9 RelaxedPrecision
                                            Decorate 9 Location 0
                                            Decorate 11 RelaxedPrecision
                                            Decorate 11 Location 1
                                            Decorate 12 RelaxedPrecision
                                            Decorate 13 RelaxedPrecision
                                            Decorate 16 RelaxedPrecision
                                            Decorate 17 RelaxedPrecision
                                            Decorate 18 RelaxedPrecision
                                            Decorate 21(vs_TEXCOORD0)Location 1
                                            Decorate 24 Location 2
                                            Decorate 29 ArrayStride 16
                                            Decorate 30 ArrayStride 16
                                            MemberDecorate 31 0 Offset 0
                                            MemberDecorate 31 1 Offset 64
                                            MemberDecorate 31 2 Offset 128
                                            Decorate 31 Block
                                            Decorate 33 DescriptorSet 1
                                            Decorate 33 Binding 0
                                            Decorate 47 Location 0
                                            MemberDecorate 96 0 BuiltIn Position
                                            MemberDecorate 96 1 BuiltIn PointSize
                                            MemberDecorate 96 2 BuiltIn ClipDistance
                                            Decorate 96 Block
                             2:             TypeVoid
                             3 : TypeFunction 2
                             6 : TypeFloat 32
                             7 : TypeVector 6(float)4
                             8 : TypePointer Output 7(fvec4)
                             9 : 8(ptr)Variable Output
                            10 : TypePointer Input 7(fvec4)
                            11 : 10(ptr)Variable Input
                            14 : 6(float)Constant 0
                            15 : 6(float)Constant 1065353216
                            19 : TypeVector 6(float)2
                            20 : TypePointer Output 19(fvec2)
              21(vs_TEXCOORD0) : 20(ptr)Variable Output
                            22 : TypeVector 6(float)3
                            23 : TypePointer Input 22(fvec3)
                            24 : 23(ptr)Variable Input
                            27 : TypeInt 32 0
                            28 : 27(int)Constant 4
                            29 : TypeArray 7(fvec4)28
                            30 : TypeArray 7(fvec4)28
                            31 : TypeStruct 29 30 7(fvec4)
                            32 : TypePointer Uniform 31(struct)
                            33 : 32(ptr)Variable Uniform
                            34 : TypeInt 32 1
                            35 : 34(int)Constant 2
                            36 : TypePointer Uniform 7(fvec4)
                            45 : TypePointer Private 7(fvec4)
                            46 : 45(ptr)Variable Private
                            47 : 23(ptr)Variable Input
                            50 : 34(int)Constant 0
                            51 : 34(int)Constant 1
                            70 : 34(int)Constant 3
                            74 : 45(ptr)Variable Private
                            94 : 27(int)Constant 1
                            95 : TypeArray 6(float)94
                            96 : TypeStruct 7(fvec4)6(float)95
                            97 : TypePointer Output 96(struct)
                            98 : 97(ptr)Variable Output
                           107 : TypePointer Output 6(float)
                           113 : TypePointer Function 7(fvec4)
                           115 : TypeVector 34(int)4
                           116 : TypePointer Function 115(ivec4)
                           118 : TypeBool
                           119 : TypeVector 118(bool)4
                           120 : TypePointer Function 119(bvec4)
                           122 : TypeVector 27(int)4
                           123 : TypePointer Function 122(ivec4)
                             4 : 2 Function None 3
                             5 : Label
                           114 : 113(ptr)Variable Function
                           117 : 116(ptr)Variable Function
                           121 : 120(ptr)Variable Function
                           124 : 123(ptr)Variable Function
                            12 : 7(fvec4)Load 11
                                            Store 9 12
                            13 : 7(fvec4)Load 9
                            16 : 7(fvec4)CompositeConstruct 14 14 14 14
                            17 : 7(fvec4)CompositeConstruct 15 15 15 15
                            18 : 7(fvec4)ExtInst 1(GLSL.std.450) 43(FClamp)13 16 17
                                            Store 9 18
                            25 : 22(fvec3)Load 24
                            26 : 19(fvec2)VectorShuffle 25 25 0 1
                            37 : 36(ptr)AccessChain 33 35
                            38 : 7(fvec4)Load 37
                            39 : 19(fvec2)VectorShuffle 38 38 0 1
                            40 : 19(fvec2)FMul 26 39
                            41 : 36(ptr)AccessChain 33 35
                            42 : 7(fvec4)Load 41
                            43 : 19(fvec2)VectorShuffle 42 42 2 3
                            44 : 19(fvec2)FAdd 40 43
                                            Store 21(vs_TEXCOORD0)44
                            48 : 22(fvec3)Load 47
                            49 : 7(fvec4)VectorShuffle 48 48 1 1 1 1
                            52 : 36(ptr)AccessChain 33 50 51
                            53 : 7(fvec4)Load 52
                            54 : 7(fvec4)FMul 49 53
                                            Store 46 54
                            55 : 36(ptr)AccessChain 33 50 50
                            56 : 7(fvec4)Load 55
                            57 : 22(fvec3)Load 47
                            58 : 7(fvec4)VectorShuffle 57 57 0 0 0 0
                            59 : 7(fvec4)FMul 56 58
                            60 : 7(fvec4)Load 46
                            61 : 7(fvec4)FAdd 59 60
                                            Store 46 61
                            62 : 36(ptr)AccessChain 33 50 35
                            63 : 7(fvec4)Load 62
                            64 : 22(fvec3)Load 47
                            65 : 7(fvec4)VectorShuffle 64 64 2 2 2 2
                            66 : 7(fvec4)FMul 63 65
                            67 : 7(fvec4)Load 46
                            68 : 7(fvec4)FAdd 66 67
                                            Store 46 68
                            69 : 7(fvec4)Load 46
                            71 : 36(ptr)AccessChain 33 50 70
                            72 : 7(fvec4)Load 71
                            73 : 7(fvec4)FAdd 69 72
                                            Store 46 73
                            75 : 7(fvec4)Load 46
                            76 : 7(fvec4)VectorShuffle 75 75 1 1 1 1
                            77 : 36(ptr)AccessChain 33 51 51
                            78 : 7(fvec4)Load 77
                            79 : 7(fvec4)FMul 76 78
                                            Store 74 79
                            80 : 36(ptr)AccessChain 33 51 50
                            81 : 7(fvec4)Load 80
                            82 : 7(fvec4)Load 46
                            83 : 7(fvec4)VectorShuffle 82 82 0 0 0 0
                            84 : 7(fvec4)FMul 81 83
                            85 : 7(fvec4)Load 74
                            86 : 7(fvec4)FAdd 84 85
                                            Store 74 86
                            87 : 36(ptr)AccessChain 33 51 35
                            88 : 7(fvec4)Load 87
                            89 : 7(fvec4)Load 46
                            90 : 7(fvec4)VectorShuffle 89 89 2 2 2 2
                            91 : 7(fvec4)FMul 88 90
                            92 : 7(fvec4)Load 74
                            93 : 7(fvec4)FAdd 91 92
                                            Store 74 93
                            99 : 36(ptr)AccessChain 33 51 70
                           100 : 7(fvec4)Load 99
                           101 : 7(fvec4)Load 46
                           102 : 7(fvec4)VectorShuffle 101 101 3 3 3 3
                           103 : 7(fvec4)FMul 100 102
                           104 : 7(fvec4)Load 74
                           105 : 7(fvec4)FAdd 103 104
                           106 : 8(ptr)AccessChain 98 50
                                            Store 106 105
                           108 : 107(ptr)AccessChain 98 50 94
                           109 : 6(float)Load 108
                           110 : 6(float)FNegate 109
                           111 : 107(ptr)AccessChain 98 50 94
                                            Store 111 110
                                            Return
                                            FunctionEnd

              Disassembly for Fragment :
              // Module Version 10000
              // Generated by (magic number): 80006
              // Id's are bound by 47

                                            Capability Shader
                             1:             ExtInstImport  "GLSL.std.450"
                                            MemoryModel Logical GLSL450
                                            EntryPoint Fragment 4  "main" 22 26 29
                                            ExecutionMode 4 OriginUpperLeft
                                            Name 22  "vs_TEXCOORD0"
                                            Decorate 9 RelaxedPrecision
                                            Decorate 12 RelaxedPrecision
                                            Decorate 12 DescriptorSet 0
                                            Decorate 12 Binding 1
                                            Decorate 13 RelaxedPrecision
                                            Decorate 16 RelaxedPrecision
                                            Decorate 16 DescriptorSet 0
                                            Decorate 16 Binding 0
                                            Decorate 17 RelaxedPrecision
                                            Decorate 22(vs_TEXCOORD0)Location 1
                                            Decorate 26 RelaxedPrecision
                                            Decorate 26 Location 0
                                            Decorate 27 RelaxedPrecision
                                            Decorate 29 RelaxedPrecision
                                            Decorate 29 Location 0
                                            Decorate 30 RelaxedPrecision
                                            Decorate 31 RelaxedPrecision
                             2:             TypeVoid
                             3 : TypeFunction 2
                             6 : TypeFloat 32
                             7 : TypeVector 6(float)4
                             8 : TypePointer Private 7(fvec4)
                             9 : 8(ptr)Variable Private
                            10 : TypeImage 6(float)2D sampled format : Unknown
                            11 : TypePointer UniformConstant 10
                            12 : 11(ptr)Variable UniformConstant
                            14 : TypeSampler
                            15 : TypePointer UniformConstant 14
                            16 : 15(ptr)Variable UniformConstant
                            18 : TypeSampledImage 10
                            20 : TypeVector 6(float)2
                            21 : TypePointer Input 20(fvec2)
              22(vs_TEXCOORD0) : 21(ptr)Variable Input
                            25 : TypePointer Output 7(fvec4)
                            26 : 25(ptr)Variable Output
                            28 : TypePointer Input 7(fvec4)
                            29 : 28(ptr)Variable Input
                            33 : TypePointer Function 7(fvec4)
                            35 : TypeInt 32 1
                            36 : TypeVector 35(int)4
                            37 : TypePointer Function 36(ivec4)
                            39 : TypeBool
                            40 : TypeVector 39(bool)4
                            41 : TypePointer Function 40(bvec4)
                            43 : TypeInt 32 0
                            44 : TypeVector 43(int)4
                            45 : TypePointer Function 44(ivec4)
                             4 : 2 Function None 3
                             5 : Label
                            34 : 33(ptr)Variable Function
                            38 : 37(ptr)Variable Function
                            42 : 41(ptr)Variable Function
                            46 : 45(ptr)Variable Function
                            13 : 10 Load 12
                            17 : 14 Load 16
                            19 : 18 SampledImage 13 17
                            23 : 20(fvec2)Load 22(vs_TEXCOORD0)
                            24 : 7(fvec4)ImageSampleImplicitLod 19 23
                                            Store 9 24
                            27 : 7(fvec4)Load 9
                            30 : 7(fvec4)Load 29
                            31 : 7(fvec4)FMul 27 30
                                            Store 26 31
                                            Return
                                            FunctionEnd

              Disassembly for Hull :
              Not present.



              //////////////////////////////////////////////////////
              Global Keywords : <none>
              Local Keywords : <none>
              --Hardware tier variant : Tier 2
              --Vertex shader for "vulkan" :
              Uses vertex data channel "Color"
              Uses vertex data channel "TexCoord0"
              Uses vertex data channel "Vertex"

              Set 2D Texture "_MainTex" to set : 0, binding : 1, used in : Fragment  using sampler in set : 0, binding : 0, used in : Fragment

              Constant Buffer "VGlobals2998864059" (144 bytes) on set : 1, binding : 0, used in : Vertex  {
                Matrix4x4 unity_MatrixVP at 64
                Matrix4x4 unity_ObjectToWorld at 0
                Vector4 _MainTex_ST at 128
              }

              Shader Disassembly :
              Disassembly for Vertex :
                  // Module Version 10000
                  // Generated by (magic number): 80006
                  // Id's are bound by 125

                                                Capability Shader
                                 1:             ExtInstImport  "GLSL.std.450"
                                                MemoryModel Logical GLSL450
                                                EntryPoint Vertex 4  "main" 9 11 21 24 47 98
                                                Name 21  "vs_TEXCOORD0"
                                                Decorate 9 RelaxedPrecision
                                                Decorate 9 Location 0
                                                Decorate 11 RelaxedPrecision
                                                Decorate 11 Location 1
                                                Decorate 12 RelaxedPrecision
                                                Decorate 13 RelaxedPrecision
                                                Decorate 16 RelaxedPrecision
                                                Decorate 17 RelaxedPrecision
                                                Decorate 18 RelaxedPrecision
                                                Decorate 21(vs_TEXCOORD0)Location 1
                                                Decorate 24 Location 2
                                                Decorate 29 ArrayStride 16
                                                Decorate 30 ArrayStride 16
                                                MemberDecorate 31 0 Offset 0
                                                MemberDecorate 31 1 Offset 64
                                                MemberDecorate 31 2 Offset 128
                                                Decorate 31 Block
                                                Decorate 33 DescriptorSet 1
                                                Decorate 33 Binding 0
                                                Decorate 47 Location 0
                                                MemberDecorate 96 0 BuiltIn Position
                                                MemberDecorate 96 1 BuiltIn PointSize
                                                MemberDecorate 96 2 BuiltIn ClipDistance
                                                Decorate 96 Block
                                 2:             TypeVoid
                                 3 : TypeFunction 2
                                 6 : TypeFloat 32
                                 7 : TypeVector 6(float)4
                                 8 : TypePointer Output 7(fvec4)
                                 9 : 8(ptr)Variable Output
                                10 : TypePointer Input 7(fvec4)
                                11 : 10(ptr)Variable Input
                                14 : 6(float)Constant 0
                                15 : 6(float)Constant 1065353216
                                19 : TypeVector 6(float)2
                                20 : TypePointer Output 19(fvec2)
                  21(vs_TEXCOORD0) : 20(ptr)Variable Output
                                22 : TypeVector 6(float)3
                                23 : TypePointer Input 22(fvec3)
                                24 : 23(ptr)Variable Input
                                27 : TypeInt 32 0
                                28 : 27(int)Constant 4
                                29 : TypeArray 7(fvec4)28
                                30 : TypeArray 7(fvec4)28
                                31 : TypeStruct 29 30 7(fvec4)
                                32 : TypePointer Uniform 31(struct)
                                33 : 32(ptr)Variable Uniform
                                34 : TypeInt 32 1
                                35 : 34(int)Constant 2
                                36 : TypePointer Uniform 7(fvec4)
                                45 : TypePointer Private 7(fvec4)
                                46 : 45(ptr)Variable Private
                                47 : 23(ptr)Variable Input
                                50 : 34(int)Constant 0
                                51 : 34(int)Constant 1
                                70 : 34(int)Constant 3
                                74 : 45(ptr)Variable Private
                                94 : 27(int)Constant 1
                                95 : TypeArray 6(float)94
                                96 : TypeStruct 7(fvec4)6(float)95
                                97 : TypePointer Output 96(struct)
                                98 : 97(ptr)Variable Output
                               107 : TypePointer Output 6(float)
                               113 : TypePointer Function 7(fvec4)
                               115 : TypeVector 34(int)4
                               116 : TypePointer Function 115(ivec4)
                               118 : TypeBool
                               119 : TypeVector 118(bool)4
                               120 : TypePointer Function 119(bvec4)
                               122 : TypeVector 27(int)4
                               123 : TypePointer Function 122(ivec4)
                                 4 : 2 Function None 3
                                 5 : Label
                               114 : 113(ptr)Variable Function
                               117 : 116(ptr)Variable Function
                               121 : 120(ptr)Variable Function
                               124 : 123(ptr)Variable Function
                                12 : 7(fvec4)Load 11
                                                Store 9 12
                                13 : 7(fvec4)Load 9
                                16 : 7(fvec4)CompositeConstruct 14 14 14 14
                                17 : 7(fvec4)CompositeConstruct 15 15 15 15
                                18 : 7(fvec4)ExtInst 1(GLSL.std.450) 43(FClamp)13 16 17
                                                Store 9 18
                                25 : 22(fvec3)Load 24
                                26 : 19(fvec2)VectorShuffle 25 25 0 1
                                37 : 36(ptr)AccessChain 33 35
                                38 : 7(fvec4)Load 37
                                39 : 19(fvec2)VectorShuffle 38 38 0 1
                                40 : 19(fvec2)FMul 26 39
                                41 : 36(ptr)AccessChain 33 35
                                42 : 7(fvec4)Load 41
                                43 : 19(fvec2)VectorShuffle 42 42 2 3
                                44 : 19(fvec2)FAdd 40 43
                                                Store 21(vs_TEXCOORD0)44
                                48 : 22(fvec3)Load 47
                                49 : 7(fvec4)VectorShuffle 48 48 1 1 1 1
                                52 : 36(ptr)AccessChain 33 50 51
                                53 : 7(fvec4)Load 52
                                54 : 7(fvec4)FMul 49 53
                                                Store 46 54
                                55 : 36(ptr)AccessChain 33 50 50
                                56 : 7(fvec4)Load 55
                                57 : 22(fvec3)Load 47
                                58 : 7(fvec4)VectorShuffle 57 57 0 0 0 0
                                59 : 7(fvec4)FMul 56 58
                                60 : 7(fvec4)Load 46
                                61 : 7(fvec4)FAdd 59 60
                                                Store 46 61
                                62 : 36(ptr)AccessChain 33 50 35
                                63 : 7(fvec4)Load 62
                                64 : 22(fvec3)Load 47
                                65 : 7(fvec4)VectorShuffle 64 64 2 2 2 2
                                66 : 7(fvec4)FMul 63 65
                                67 : 7(fvec4)Load 46
                                68 : 7(fvec4)FAdd 66 67
                                                Store 46 68
                                69 : 7(fvec4)Load 46
                                71 : 36(ptr)AccessChain 33 50 70
                                72 : 7(fvec4)Load 71
                                73 : 7(fvec4)FAdd 69 72
                                                Store 46 73
                                75 : 7(fvec4)Load 46
                                76 : 7(fvec4)VectorShuffle 75 75 1 1 1 1
                                77 : 36(ptr)AccessChain 33 51 51
                                78 : 7(fvec4)Load 77
                                79 : 7(fvec4)FMul 76 78
                                                Store 74 79
                                80 : 36(ptr)AccessChain 33 51 50
                                81 : 7(fvec4)Load 80
                                82 : 7(fvec4)Load 46
                                83 : 7(fvec4)VectorShuffle 82 82 0 0 0 0
                                84 : 7(fvec4)FMul 81 83
                                85 : 7(fvec4)Load 74
                                86 : 7(fvec4)FAdd 84 85
                                                Store 74 86
                                87 : 36(ptr)AccessChain 33 51 35
                                88 : 7(fvec4)Load 87
                                89 : 7(fvec4)Load 46
                                90 : 7(fvec4)VectorShuffle 89 89 2 2 2 2
                                91 : 7(fvec4)FMul 88 90
                                92 : 7(fvec4)Load 74
                                93 : 7(fvec4)FAdd 91 92
                                                Store 74 93
                                99 : 36(ptr)AccessChain 33 51 70
                               100 : 7(fvec4)Load 99
                               101 : 7(fvec4)Load 46
                               102 : 7(fvec4)VectorShuffle 101 101 3 3 3 3
                               103 : 7(fvec4)FMul 100 102
                               104 : 7(fvec4)Load 74
                               105 : 7(fvec4)FAdd 103 104
                               106 : 8(ptr)AccessChain 98 50
                                                Store 106 105
                               108 : 107(ptr)AccessChain 98 50 94
                               109 : 6(float)Load 108
                               110 : 6(float)FNegate 109
                               111 : 107(ptr)AccessChain 98 50 94
                                                Store 111 110
                                                Return
                                                FunctionEnd

                  Disassembly for Fragment :
                  // Module Version 10000
                  // Generated by (magic number): 80006
                  // Id's are bound by 47

                                                Capability Shader
                                 1:             ExtInstImport  "GLSL.std.450"
                                                MemoryModel Logical GLSL450
                                                EntryPoint Fragment 4  "main" 22 26 29
                                                ExecutionMode 4 OriginUpperLeft
                                                Name 22  "vs_TEXCOORD0"
                                                Decorate 9 RelaxedPrecision
                                                Decorate 12 RelaxedPrecision
                                                Decorate 12 DescriptorSet 0
                                                Decorate 12 Binding 1
                                                Decorate 13 RelaxedPrecision
                                                Decorate 16 RelaxedPrecision
                                                Decorate 16 DescriptorSet 0
                                                Decorate 16 Binding 0
                                                Decorate 17 RelaxedPrecision
                                                Decorate 22(vs_TEXCOORD0)Location 1
                                                Decorate 26 RelaxedPrecision
                                                Decorate 26 Location 0
                                                Decorate 27 RelaxedPrecision
                                                Decorate 29 RelaxedPrecision
                                                Decorate 29 Location 0
                                                Decorate 30 RelaxedPrecision
                                                Decorate 31 RelaxedPrecision
                                 2:             TypeVoid
                                 3 : TypeFunction 2
                                 6 : TypeFloat 32
                                 7 : TypeVector 6(float)4
                                 8 : TypePointer Private 7(fvec4)
                                 9 : 8(ptr)Variable Private
                                10 : TypeImage 6(float)2D sampled format : Unknown
                                11 : TypePointer UniformConstant 10
                                12 : 11(ptr)Variable UniformConstant
                                14 : TypeSampler
                                15 : TypePointer UniformConstant 14
                                16 : 15(ptr)Variable UniformConstant
                                18 : TypeSampledImage 10
                                20 : TypeVector 6(float)2
                                21 : TypePointer Input 20(fvec2)
                  22(vs_TEXCOORD0) : 21(ptr)Variable Input
                                25 : TypePointer Output 7(fvec4)
                                26 : 25(ptr)Variable Output
                                28 : TypePointer Input 7(fvec4)
                                29 : 28(ptr)Variable Input
                                33 : TypePointer Function 7(fvec4)
                                35 : TypeInt 32 1
                                36 : TypeVector 35(int)4
                                37 : TypePointer Function 36(ivec4)
                                39 : TypeBool
                                40 : TypeVector 39(bool)4
                                41 : TypePointer Function 40(bvec4)
                                43 : TypeInt 32 0
                                44 : TypeVector 43(int)4
                                45 : TypePointer Function 44(ivec4)
                                 4 : 2 Function None 3
                                 5 : Label
                                34 : 33(ptr)Variable Function
                                38 : 37(ptr)Variable Function
                                42 : 41(ptr)Variable Function
                                46 : 45(ptr)Variable Function
                                13 : 10 Load 12
                                17 : 14 Load 16
                                19 : 18 SampledImage 13 17
                                23 : 20(fvec2)Load 22(vs_TEXCOORD0)
                                24 : 7(fvec4)ImageSampleImplicitLod 19 23
                                                Store 9 24
                                27 : 7(fvec4)Load 9
                                30 : 7(fvec4)Load 29
                                31 : 7(fvec4)FMul 27 30
                                                Store 26 31
                                                Return
                                                FunctionEnd

                  Disassembly for Hull :
                  Not present.



                  //////////////////////////////////////////////////////
                  Global Keywords : <none>
                  Local Keywords : <none>
                  --Hardware tier variant : Tier 3
                  --Vertex shader for "vulkan" :
                  Uses vertex data channel "Color"
                  Uses vertex data channel "TexCoord0"
                  Uses vertex data channel "Vertex"

                  Set 2D Texture "_MainTex" to set : 0, binding : 1, used in : Fragment  using sampler in set : 0, binding : 0, used in : Fragment

                  Constant Buffer "VGlobals2998864059" (144 bytes) on set : 1, binding : 0, used in : Vertex  {
                    Matrix4x4 unity_MatrixVP at 64
                    Matrix4x4 unity_ObjectToWorld at 0
                    Vector4 _MainTex_ST at 128
                  }

                  Shader Disassembly :
                  Disassembly for Vertex :
                      // Module Version 10000
                      // Generated by (magic number): 80006
                      // Id's are bound by 125

                                                    Capability Shader
                                     1:             ExtInstImport  "GLSL.std.450"
                                                    MemoryModel Logical GLSL450
                                                    EntryPoint Vertex 4  "main" 9 11 21 24 47 98
                                                    Name 21  "vs_TEXCOORD0"
                                                    Decorate 9 RelaxedPrecision
                                                    Decorate 9 Location 0
                                                    Decorate 11 RelaxedPrecision
                                                    Decorate 11 Location 1
                                                    Decorate 12 RelaxedPrecision
                                                    Decorate 13 RelaxedPrecision
                                                    Decorate 16 RelaxedPrecision
                                                    Decorate 17 RelaxedPrecision
                                                    Decorate 18 RelaxedPrecision
                                                    Decorate 21(vs_TEXCOORD0)Location 1
                                                    Decorate 24 Location 2
                                                    Decorate 29 ArrayStride 16
                                                    Decorate 30 ArrayStride 16
                                                    MemberDecorate 31 0 Offset 0
                                                    MemberDecorate 31 1 Offset 64
                                                    MemberDecorate 31 2 Offset 128
                                                    Decorate 31 Block
                                                    Decorate 33 DescriptorSet 1
                                                    Decorate 33 Binding 0
                                                    Decorate 47 Location 0
                                                    MemberDecorate 96 0 BuiltIn Position
                                                    MemberDecorate 96 1 BuiltIn PointSize
                                                    MemberDecorate 96 2 BuiltIn ClipDistance
                                                    Decorate 96 Block
                                     2:             TypeVoid
                                     3 : TypeFunction 2
                                     6 : TypeFloat 32
                                     7 : TypeVector 6(float)4
                                     8 : TypePointer Output 7(fvec4)
                                     9 : 8(ptr)Variable Output
                                    10 : TypePointer Input 7(fvec4)
                                    11 : 10(ptr)Variable Input
                                    14 : 6(float)Constant 0
                                    15 : 6(float)Constant 1065353216
                                    19 : TypeVector 6(float)2
                                    20 : TypePointer Output 19(fvec2)
                      21(vs_TEXCOORD0) : 20(ptr)Variable Output
                                    22 : TypeVector 6(float)3
                                    23 : TypePointer Input 22(fvec3)
                                    24 : 23(ptr)Variable Input
                                    27 : TypeInt 32 0
                                    28 : 27(int)Constant 4
                                    29 : TypeArray 7(fvec4)28
                                    30 : TypeArray 7(fvec4)28
                                    31 : TypeStruct 29 30 7(fvec4)
                                    32 : TypePointer Uniform 31(struct)
                                    33 : 32(ptr)Variable Uniform
                                    34 : TypeInt 32 1
                                    35 : 34(int)Constant 2
                                    36 : TypePointer Uniform 7(fvec4)
                                    45 : TypePointer Private 7(fvec4)
                                    46 : 45(ptr)Variable Private
                                    47 : 23(ptr)Variable Input
                                    50 : 34(int)Constant 0
                                    51 : 34(int)Constant 1
                                    70 : 34(int)Constant 3
                                    74 : 45(ptr)Variable Private
                                    94 : 27(int)Constant 1
                                    95 : TypeArray 6(float)94
                                    96 : TypeStruct 7(fvec4)6(float)95
                                    97 : TypePointer Output 96(struct)
                                    98 : 97(ptr)Variable Output
                                   107 : TypePointer Output 6(float)
                                   113 : TypePointer Function 7(fvec4)
                                   115 : TypeVector 34(int)4
                                   116 : TypePointer Function 115(ivec4)
                                   118 : TypeBool
                                   119 : TypeVector 118(bool)4
                                   120 : TypePointer Function 119(bvec4)
                                   122 : TypeVector 27(int)4
                                   123 : TypePointer Function 122(ivec4)
                                     4 : 2 Function None 3
                                     5 : Label
                                   114 : 113(ptr)Variable Function
                                   117 : 116(ptr)Variable Function
                                   121 : 120(ptr)Variable Function
                                   124 : 123(ptr)Variable Function
                                    12 : 7(fvec4)Load 11
                                                    Store 9 12
                                    13 : 7(fvec4)Load 9
                                    16 : 7(fvec4)CompositeConstruct 14 14 14 14
                                    17 : 7(fvec4)CompositeConstruct 15 15 15 15
                                    18 : 7(fvec4)ExtInst 1(GLSL.std.450) 43(FClamp)13 16 17
                                                    Store 9 18
                                    25 : 22(fvec3)Load 24
                                    26 : 19(fvec2)VectorShuffle 25 25 0 1
                                    37 : 36(ptr)AccessChain 33 35
                                    38 : 7(fvec4)Load 37
                                    39 : 19(fvec2)VectorShuffle 38 38 0 1
                                    40 : 19(fvec2)FMul 26 39
                                    41 : 36(ptr)AccessChain 33 35
                                    42 : 7(fvec4)Load 41
                                    43 : 19(fvec2)VectorShuffle 42 42 2 3
                                    44 : 19(fvec2)FAdd 40 43
                                                    Store 21(vs_TEXCOORD0)44
                                    48 : 22(fvec3)Load 47
                                    49 : 7(fvec4)VectorShuffle 48 48 1 1 1 1
                                    52 : 36(ptr)AccessChain 33 50 51
                                    53 : 7(fvec4)Load 52
                                    54 : 7(fvec4)FMul 49 53
                                                    Store 46 54
                                    55 : 36(ptr)AccessChain 33 50 50
                                    56 : 7(fvec4)Load 55
                                    57 : 22(fvec3)Load 47
                                    58 : 7(fvec4)VectorShuffle 57 57 0 0 0 0
                                    59 : 7(fvec4)FMul 56 58
                                    60 : 7(fvec4)Load 46
                                    61 : 7(fvec4)FAdd 59 60
                                                    Store 46 61
                                    62 : 36(ptr)AccessChain 33 50 35
                                    63 : 7(fvec4)Load 62
                                    64 : 22(fvec3)Load 47
                                    65 : 7(fvec4)VectorShuffle 64 64 2 2 2 2
                                    66 : 7(fvec4)FMul 63 65
                                    67 : 7(fvec4)Load 46
                                    68 : 7(fvec4)FAdd 66 67
                                                    Store 46 68
                                    69 : 7(fvec4)Load 46
                                    71 : 36(ptr)AccessChain 33 50 70
                                    72 : 7(fvec4)Load 71
                                    73 : 7(fvec4)FAdd 69 72
                                                    Store 46 73
                                    75 : 7(fvec4)Load 46
                                    76 : 7(fvec4)VectorShuffle 75 75 1 1 1 1
                                    77 : 36(ptr)AccessChain 33 51 51
                                    78 : 7(fvec4)Load 77
                                    79 : 7(fvec4)FMul 76 78
                                                    Store 74 79
                                    80 : 36(ptr)AccessChain 33 51 50
                                    81 : 7(fvec4)Load 80
                                    82 : 7(fvec4)Load 46
                                    83 : 7(fvec4)VectorShuffle 82 82 0 0 0 0
                                    84 : 7(fvec4)FMul 81 83
                                    85 : 7(fvec4)Load 74
                                    86 : 7(fvec4)FAdd 84 85
                                                    Store 74 86
                                    87 : 36(ptr)AccessChain 33 51 35
                                    88 : 7(fvec4)Load 87
                                    89 : 7(fvec4)Load 46
                                    90 : 7(fvec4)VectorShuffle 89 89 2 2 2 2
                                    91 : 7(fvec4)FMul 88 90
                                    92 : 7(fvec4)Load 74
                                    93 : 7(fvec4)FAdd 91 92
                                                    Store 74 93
                                    99 : 36(ptr)AccessChain 33 51 70
                                   100 : 7(fvec4)Load 99
                                   101 : 7(fvec4)Load 46
                                   102 : 7(fvec4)VectorShuffle 101 101 3 3 3 3
                                   103 : 7(fvec4)FMul 100 102
                                   104 : 7(fvec4)Load 74
                                   105 : 7(fvec4)FAdd 103 104
                                   106 : 8(ptr)AccessChain 98 50
                                                    Store 106 105
                                   108 : 107(ptr)AccessChain 98 50 94
                                   109 : 6(float)Load 108
                                   110 : 6(float)FNegate 109
                                   111 : 107(ptr)AccessChain 98 50 94
                                                    Store 111 110
                                                    Return
                                                    FunctionEnd

                      Disassembly for Fragment :
                      // Module Version 10000
                      // Generated by (magic number): 80006
                      // Id's are bound by 47

                                                    Capability Shader
                                     1:             ExtInstImport  "GLSL.std.450"
                                                    MemoryModel Logical GLSL450
                                                    EntryPoint Fragment 4  "main" 22 26 29
                                                    ExecutionMode 4 OriginUpperLeft
                                                    Name 22  "vs_TEXCOORD0"
                                                    Decorate 9 RelaxedPrecision
                                                    Decorate 12 RelaxedPrecision
                                                    Decorate 12 DescriptorSet 0
                                                    Decorate 12 Binding 1
                                                    Decorate 13 RelaxedPrecision
                                                    Decorate 16 RelaxedPrecision
                                                    Decorate 16 DescriptorSet 0
                                                    Decorate 16 Binding 0
                                                    Decorate 17 RelaxedPrecision
                                                    Decorate 22(vs_TEXCOORD0)Location 1
                                                    Decorate 26 RelaxedPrecision
                                                    Decorate 26 Location 0
                                                    Decorate 27 RelaxedPrecision
                                                    Decorate 29 RelaxedPrecision
                                                    Decorate 29 Location 0
                                                    Decorate 30 RelaxedPrecision
                                                    Decorate 31 RelaxedPrecision
                                     2:             TypeVoid
                                     3 : TypeFunction 2
                                     6 : TypeFloat 32
                                     7 : TypeVector 6(float)4
                                     8 : TypePointer Private 7(fvec4)
                                     9 : 8(ptr)Variable Private
                                    10 : TypeImage 6(float)2D sampled format : Unknown
                                    11 : TypePointer UniformConstant 10
                                    12 : 11(ptr)Variable UniformConstant
                                    14 : TypeSampler
                                    15 : TypePointer UniformConstant 14
                                    16 : 15(ptr)Variable UniformConstant
                                    18 : TypeSampledImage 10
                                    20 : TypeVector 6(float)2
                                    21 : TypePointer Input 20(fvec2)
                      22(vs_TEXCOORD0) : 21(ptr)Variable Input
                                    25 : TypePointer Output 7(fvec4)
                                    26 : 25(ptr)Variable Output
                                    28 : TypePointer Input 7(fvec4)
                                    29 : 28(ptr)Variable Input
                                    33 : TypePointer Function 7(fvec4)
                                    35 : TypeInt 32 1
                                    36 : TypeVector 35(int)4
                                    37 : TypePointer Function 36(ivec4)
                                    39 : TypeBool
                                    40 : TypeVector 39(bool)4
                                    41 : TypePointer Function 40(bvec4)
                                    43 : TypeInt 32 0
                                    44 : TypeVector 43(int)4
                                    45 : TypePointer Function 44(ivec4)
                                     4 : 2 Function None 3
                                     5 : Label
                                    34 : 33(ptr)Variable Function
                                    38 : 37(ptr)Variable Function
                                    42 : 41(ptr)Variable Function
                                    46 : 45(ptr)Variable Function
                                    13 : 10 Load 12
                                    17 : 14 Load 16
                                    19 : 18 SampledImage 13 17
                                    23 : 20(fvec2)Load 22(vs_TEXCOORD0)
                                    24 : 7(fvec4)ImageSampleImplicitLod 19 23
                                                    Store 9 24
                                    27 : 7(fvec4)Load 9
                                    30 : 7(fvec4)Load 29
                                    31 : 7(fvec4)FMul 27 30
                                                    Store 26 31
                                                    Return
                                                    FunctionEnd

                      Disassembly for Hull :
                      Not present.



                       }
        }
    }
