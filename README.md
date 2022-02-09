# net6-profiled-aot-repro

Test project using Profiled AOT

I recorded `custom.aprof` via a `Debug` build:

```dotnetcli
> dotnet build HelloAndroid/HelloAndroid.csproj -t:BuildAndStartAotProfiling
> dotnet build HelloAndroid/HelloAndroid.csproj -t:FinishAotProfiling
```

This makes use of:

* https://github.com/jonathanpeppers/Mono.Profiler.Android
* https://www.nuget.org/packages/Mono.AotProfiler.Android

To run using `custom.aprof`, run a `Release` build:

```dotnetcli
> dotnet build HelloAndroid/HelloAndroid.csproj -c Release -t:Run
```

If you configure logging such as:

```
> adb shell setprop debug.mono.log default,timing=bare,assembly,mono_log_level=debug,mono_log_mask=aot
```

Afer launching the app:

```
> adb logcat -d | grep 'AOT NOT FOUND'
```

Results with:

```
02-09 13:46:10.155 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) <Module>:runtime_invoke_void__this___object 
(object,intptr,intptr,intptr).
02-09 13:46:10.157 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) <Module>:runtime_invoke_void_char**_char**_int 
(object,intptr,intptr,intptr).
02-09 13:46:10.158 29929 29929 D Mono    : AOT NOT FOUND: (wrapper alloc) object:AllocSmall (intptr,intptr).
02-09 13:46:10.158 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) object:runtime_invoke_void (object,intptr,intptr,intptr).
02-09 13:46:10.158 29929 29929 D Mono    : AOT NOT FOUND: (wrapper alloc) object:AllocVector (intptr,intptr).
02-09 13:46:10.158 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper___emul_lmul_ovf_un (long,long).
02-09 13:46:10.159 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) object:runtime_invoke_void (object,intptr,intptr,intptr).
02-09 13:46:10.160 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:type_is_assignable_from 
(System.Type,System.Type).
02-09 13:46:10.160 29929 29929 D Mono    : AOT NOT FOUND: (wrapper stelemref) object:virt_stelemref_class_small_idepth (intptr,object).
02-09 13:46:10.160 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeType:MakeGenericType (System.Type,System.Type[]).
02-09 13:46:10.161 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeType:GetConstructors_native 
(System.RuntimeType,System.Reflection.BindingFlags).
02-09 13:46:10.161 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) 
System.Reflection.RuntimeMethodInfo:GetMethodFromHandleInternalType_native (intptr,intptr,bool).
02-09 13:46:10.161 29929 29929 D Mono    : AOT NOT FOUND: (wrapper stelemref) object:virt_stelemref_sealed_class (intptr,object).
02-09 13:46:10.161 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Mono.RuntimeGPtrArrayHandle:GPtrArrayFree 
(Mono.RuntimeStructs/GPtrArray*).
02-09 13:46:10.162 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.MonoMethodInfo:get_parameter_info 
(intptr,System.Reflection.MemberInfo).
02-09 13:46:10.162 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.MonoMethodInfo:get_method_attributes (intptr).
02-09 13:46:10.162 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.RuntimeConstructorInfo:InternalInvoke 
(System.Reflection.RuntimeConstructorInfo,object,object[],System.Exception&).
02-09 13:46:10.162 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) object:runtime_invoke_void__this__ (object,intptr,intptr,intptr).
02-09 13:46:10.163 29929 29929 D Mono    : AOT NOT FOUND: (wrapper castclass) object:__castclass_with_cache (object,intptr,intptr).
02-09 13:46:10.163 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_marshal_isinst_with_cache 
(object,intptr,intptr).
02-09 13:46:10.163 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-managed) string:.ctor (char*).
02-09 13:46:10.163 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) string:FastAllocateString (int).
02-09 13:46:10.164 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:is_subclass_of (intptr,intptr).
02-09 13:46:10.169 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) object:runtime_invoke_void (object,intptr,intptr,intptr).
02-09 13:46:10.170 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) <Module>:runtime_invoke_void_JnienvInitializeArgs* 
(object,intptr,intptr,intptr).
02-09 13:46:10.170 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Android.Runtime.JNIEnv:monodroid_timing_start (string).
02-09 13:46:10.170 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_marshal_lookup_pinvoke (intptr).
02-09 13:46:10.170 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_string_to_utf8str (object).
02-09 13:46:10.171 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_marshal_free (intptr).
02-09 13:46:10.171 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_ves_icall_object_new_specific (intptr).
02-09 13:46:10.171 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) object:runtime_invoke_void (object,intptr,intptr,intptr).
02-09 13:46:10.172 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:GetCorElementType (System.RuntimeType).
02-09 13:46:10.172 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeType:make_byref_type (System.RuntimeType).
02-09 13:46:10.173 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:HasInstantiation (System.RuntimeType).
02-09 13:46:10.173 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:IsByRefLike (System.RuntimeType).
02-09 13:46:10.174 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:IsGenericVariable (System.RuntimeType).
02-09 13:46:10.174 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeType:CreateInstanceInternal (System.Type).
02-09 13:46:10.174 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Runtime.InteropServices.Marshal:PtrToStructureInternal 
(intptr,object,bool).
02-09 13:46:10.174 29929 29929 D Mono    : AOT NOT FOUND: (wrapper other) Java.Interop.JavaVMInterface:PtrToStructure (intptr,object).
02-09 13:46:10.174 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) <Module>:runtime_invoke_void_intptr_object (object,intptr,intptr,intptr).
02-09 13:46:10.175 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_ftnptr_to_delegate (intptr,intptr).
02-09 13:46:10.175 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:wrapper_native_0x73acc56c60 (intptr).
02-09 13:46:10.175 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:wrapper_native_0x73acc56cb8 
(intptr,intptr&,Java.Interop.JavaVMThreadAttachArgs&).
02-09 13:46:10.175 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:wrapper_native_0x73acc56cc0 (intptr).
02-09 13:46:10.175 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:wrapper_native_0x73acc56d0c (intptr,intptr&,int).
02-09 13:46:10.175 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:wrapper_native_0x73acc56d44 (intptr,intptr&,intptr).
02-09 13:46:10.176 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Threading.Monitor:Exit (object).
02-09 13:46:10.176 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_get_java_vm 
(intptr,intptr&).
02-09 13:46:10.179 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_new_global_ref 
(intptr,intptr).
02-09 13:46:10.179 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Android.Runtime.AndroidObjectReferenceManager:_monodroid_gref_get ().
02-09 13:46:10.179 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Android.Runtime.Logger:monodroid_get_log_categories ().
02-09 13:46:10.179 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Android.Runtime.JNIEnv:_monodroid_gref_log_new 
(intptr,byte,intptr,byte,string,int,System.Text.StringBuilder,int).
02-09 13:46:10.179 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_string_builder_to_utf8 (object).
02-09 13:46:10.180 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_gc_alloc_obj (intptr,intptr).
02-09 13:46:10.181 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_find_class 
(intptr,intptr&,string).
02-09 13:46:10.181 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_delete_local_ref 
(intptr,intptr).
02-09 13:46:10.181 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_get_method_id 
(intptr,intptr&,intptr,string,string).
02-09 13:46:10.182 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Android.Runtime.JNIEnv:_monodroid_gref_log_delete 
(intptr,byte,string,int,System.Text.StringBuilder,int).
02-09 13:46:10.182 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_delete_global_ref 
(intptr,intptr).
02-09 13:46:10.183 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_register_natives 
(intptr,intptr&,intptr,Java.Interop.JniNativeMethodRegistration[],int).
02-09 13:46:10.183 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_delegate_to_ftnptr (object).
02-09 13:46:10.183 29929 29929 D Mono    : AOT NOT FOUND: (wrapper native-to-managed) Java.Interop.ManagedPeer:Construct 
(intptr,intptr,intptr,intptr,intptr,intptr).
02-09 13:46:10.183 29929 29929 D Mono    : AOT NOT FOUND: (wrapper native-to-managed) Java.Interop.ManagedPeer:RegisterNativeMembers 
(intptr,intptr,intptr,intptr,intptr).
02-09 13:46:10.184 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_struct_delete_old (intptr,intptr).
02-09 13:46:10.184 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Threading.Thread:GetCurrentThread ().
02-09 13:46:10.184 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Android.Runtime.JNIEnv:monodroid_timing_stop (intptr,string).
02-09 13:46:10.189 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) <Module>:runtime_invoke_void_intptr_int_intptr_intptr_int 
(object,intptr,intptr,intptr).
02-09 13:46:10.190 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-managed) string:.ctor (char*,int,int).
02-09 13:46:10.190 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:internal_from_name 
(string,System.Threading.StackCrawlMark&,System.Reflection.Assembly,bool,bool).
02-09 13:46:10.190 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.TypeManager:monodroid_TypeManager_get_java_class_name 
(intptr).
02-09 13:46:10.191 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-managed) string:.ctor (sbyte*).
02-09 13:46:10.191 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Android.Runtime.JNIEnv:monodroid_free (intptr).
02-09 13:46:10.192 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:GetModule (System.RuntimeType).
02-09 13:46:10.192 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.RuntimeModule:GetGuidInternal (intptr,byte[]).
02-09 13:46:10.192 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Android.Runtime.JNIEnv:monodroid_typemap_managed_to_java 
(System.Type,byte*).
02-09 13:46:10.194 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Environment:GetProcessorCount ().
02-09 13:46:10.194 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Interop/Sys:GetEnv (string).
02-09 13:46:10.195 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_generic_class_init (intptr).
02-09 13:46:10.195 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Interop/Globalization:LoadICU ().
02-09 13:46:10.197 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Interop/Sys:GetNonCryptographicallySecureRandomBytes (byte*,int).
02-09 13:46:10.197 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Interop/Globalization:GetSortHandle (string,intptr&).
02-09 13:46:10.198 29929 29929 D Mono    : AOT NOT FOUND: System.Buffers.ArrayPool`1<int>:.cctor ().
02-09 13:46:10.199 29929 29929 D Mono    : AOT NOT FOUND: System.Buffers.TlsOverPerCoreLockedStacksArrayPool`1<int>:.ctor ().
02-09 13:46:10.199 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_gc_alloc_vector (intptr,intptr,intptr).
02-09 13:46:10.199 29929 29929 D Mono    : AOT NOT FOUND: System.Buffers.ArrayPool`1<int>:.ctor ().
02-09 13:46:10.200 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:GetAttributes (System.RuntimeType).
02-09 13:46:10.200 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:GetBaseType (System.RuntimeType).
02-09 13:46:10.201 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Mono.SafeStringMarshal:StringToUtf8_icall (string&).
02-09 13:46:10.201 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeType:GetMethodsByName_native 
(System.RuntimeType,intptr,System.Reflection.BindingFlags,System.RuntimeType/MemberListType).
02-09 13:46:10.201 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Mono.SafeStringMarshal:GFree (intptr).
02-09 13:46:10.202 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.MonoMethodInfo:get_method_info 
(intptr,System.Reflection.MonoMethodInfo&).
02-09 13:46:10.202 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Delegate:CreateDelegate_internal 
(System.Type,object,System.Reflection.MethodInfo,bool).
02-09 13:46:10.204 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeType:get_Name (System.RuntimeType).
02-09 13:46:10.204 29929 29929 D Mono    : AOT NOT FOUND: (wrapper native-to-managed) Android.Runtime.JNINativeWrapper:Wrap_JniMarshal_PPL_V 
(intptr,intptr,intptr).
02-09 13:46:10.205 29929 29929 D Mono    : AOT NOT FOUND: (wrapper native-to-managed) Android.Runtime.JNINativeWrapper:Wrap_JniMarshal_PPLLLL_V 
(intptr,intptr,intptr,intptr,intptr,intptr).
02-09 13:46:10.205 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Android.Runtime.JNIEnv:_monodroid_get_identity_hash_code 
(intptr,intptr).
02-09 13:46:10.206 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_get_string_length 
(intptr,intptr).
02-09 13:46:10.206 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_get_string_chars 
(intptr,intptr,bool*).
02-09 13:46:10.206 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_release_string_chars 
(intptr,intptr,char*).
02-09 13:46:10.207 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:IsGenericTypeDefinition (System.RuntimeType).
02-09 13:46:10.207 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_get_array_length 
(intptr,intptr).
02-09 13:46:10.208 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Runtime.CompilerServices.RuntimeHelpers:InternalGetHashCode 
(object).
02-09 13:46:10.208 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Array:FastCopy (System.Array,int,System.Array,int,int).
02-09 13:46:10.209 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_get_object_class 
(intptr,intptr).
02-09 13:46:10.210 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeType:GetFields_native 
(System.RuntimeType,intptr,System.Reflection.BindingFlags,System.RuntimeType/MemberListType).
02-09 13:46:10.210 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.FieldInfo:internal_from_handle_type (intptr,intptr).
02-09 13:46:10.213 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Enum:InternalGetUnderlyingType (System.RuntimeType).
02-09 13:46:10.214 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Enum:GetEnumValuesAndNames 
(System.RuntimeType,ulong[]&,string[]&).
02-09 13:46:10.215 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.CustomAttribute:IsDefinedInternal 
(System.Reflection.ICustomAttributeProvider,System.Type).
02-09 13:46:10.216 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Enum:InternalGetCorElementType (System.Enum).
02-09 13:46:10.216 29929 29929 D Mono    : AOT NOT FOUND: System.Array:BinarySearch<ulong> (ulong[],ulong).
02-09 13:46:10.216 29929 29929 D Mono    : AOT NOT FOUND: System.Array:BinarySearch<ulong> 
(ulong[],int,int,ulong,System.Collections.Generic.IComparer`1<ulong>).
02-09 13:46:10.217 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.ArraySortHelper`1<ulong>:get_Default ().
02-09 13:46:10.217 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.ArraySortHelper`1<ulong>:.cctor ().
02-09 13:46:10.217 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.ArraySortHelper`1<ulong>:.ctor ().
02-09 13:46:10.217 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.ArraySortHelper`1<ulong>:BinarySearch 
(ulong[],int,int,ulong,System.Collections.Generic.IComparer`1<ulong>).
02-09 13:46:10.217 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.Comparer`1<ulong>:get_Default ().
02-09 13:46:10.217 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.Comparer`1<ulong>:CreateComparer ().
02-09 13:46:10.218 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.GenericComparer`1<ulong>:.ctor ().
02-09 13:46:10.218 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.ArraySortHelper`1<ulong>:InternalBinarySearch 
(ulong[],int,int,ulong,System.Collections.Generic.IComparer`1<ulong>).
02-09 13:46:10.218 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.GenericComparer`1<ulong>:Compare (ulong,ulong).
02-09 13:46:10.219 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.Emit.AssemblyBuilder:basic_init 
(System.Reflection.Emit.AssemblyBuilder).
02-09 13:46:10.220 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Interop/Sys:GetCryptographicallySecureRandomBytes (byte*,int).
02-09 13:46:10.220 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.Dictionary`2<string, int>:.ctor (int).
02-09 13:46:10.220 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.Dictionary`2<string, int>:.ctor 
(int,System.Collections.Generic.IEqualityComparer`1<string>).
02-09 13:46:10.221 29929 29929 D Mono    : AOT NOT FOUND: System.Collections.Generic.Dictionary`2<string, int>:Initialize (int).
02-09 13:46:10.221 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.Emit.ModuleBuilder:basic_init 
(System.Reflection.Emit.ModuleBuilder).
02-09 13:46:10.222 29929 29929 D Mono    : AOT NOT FOUND: (wrapper alloc) object:AllocString (intptr,int).
02-09 13:46:10.228 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.RuntimeTypeHandle:GetAssembly (System.RuntimeType).
02-09 13:46:10.229 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.Emit.TypeBuilder:create_runtime_class 
(System.Reflection.Emit.TypeBuilder).
02-09 13:46:10.229 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.Emit.ModuleBuilder:set_wrappers_type 
(System.Reflection.Emit.ModuleBuilder,System.Type).
02-09 13:46:10.230 29929 29929 D Mono    : AOT NOT FOUND: (wrapper stelemref) object:virt_stelemref_object (intptr,object).
02-09 13:46:10.230 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) 
<Module>:runtime_invoke_void__this___object_object_int_int_object_object_object (object,intptr,intptr,intptr).
02-09 13:46:10.230 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Reflection.Emit.DynamicMethod:create_dynamic_method 
(System.Reflection.Emit.DynamicMethod).
02-09 13:46:10.231 29929 29929 D Mono    : AOT NOT FOUND: (wrapper dynamic-method) Android.Runtime.DynamicMethodNameCounter:1 (intptr,object[]).
02-09 13:46:10.232 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) 
System.Runtime.CompilerServices.RuntimeHelpers:GetUninitializedObjectInternal (intptr).
02-09 13:46:10.233 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Runtime.InteropServices.GCHandle:InternalAlloc 
(object,System.Runtime.InteropServices.GCHandleType).
02-09 13:46:10.237 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Runtime.InteropServices.GCHandle:InternalGet (intptr).
02-09 13:46:10.237 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Java.Interop.NativeMethods:java_interop_jnienv_is_same_object 
(intptr,intptr,intptr).
02-09 13:46:10.239 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) 
Java.Interop.NativeMethods:java_interop_jnienv_call_nonvirtual_void_method_a (intptr,intptr&,intptr,intptr,intptr,intptr).
02-09 13:46:10.239 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.GC:get_ephemeron_tombstone ().
02-09 13:46:10.253 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Interop/Globalization:GetDefaultLocaleName (char*,int).
02-09 13:46:10.254 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Interop/Globalization:GetLocaleName (string,char*,int).
02-09 13:46:10.254 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) object:__icall_wrapper_mono_marshal_string_to_utf16 (object).
02-09 13:46:10.255 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Interop/Globalization:GetLocaleInfoString 
(string,uint,char*,int,string).
02-09 13:46:10.256 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Interop/Globalization:GetLocaleInfoInt (string,uint,int&).
02-09 13:46:10.256 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Interop/Globalization:GetLocaleInfoGroupingSizes 
(string,uint,int&,int&).
02-09 13:46:10.258 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Math:Ceiling (double).
02-09 13:46:10.258 29929 29929 D Mono    : AOT NOT FOUND: System.Buffers.ArrayPool`1<char>:.cctor ().
02-09 13:46:10.258 29929 29929 D Mono    : AOT NOT FOUND: System.Buffers.TlsOverPerCoreLockedStacksArrayPool`1<char>:.ctor ().
02-09 13:46:10.259 29929 29929 D Mono    : AOT NOT FOUND: System.Buffers.ArrayPool`1<char>:.ctor ().
02-09 13:46:10.259 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-managed) string:.ctor (System.ReadOnlySpan`1<char>).
02-09 13:46:10.259 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) object:runtime_invoke_void (object,intptr,intptr,intptr).
02-09 13:46:10.261 29929 29929 D Mono    : AOT NOT FOUND: System.Array/EmptyArray`1<char>:.cctor ().
02-09 13:46:10.262 29929 29929 D Mono    : AOT NOT FOUND: (wrapper synchronized) System.IO.TextWriter/SyncTextWriter:WriteLine (string).
02-09 13:46:10.263 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) <Module>:runtime_invoke_void_object_object_byte_uint_intptr& 
(object,intptr,intptr,intptr).
02-09 13:46:10.263 29929 29929 D Mono    : AOT NOT FOUND: (wrapper runtime-invoke) <Module>:runtime_invoke_void_object_intptr_intptr& 
(object,intptr,intptr,intptr).
02-09 13:46:10.264 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.GC:_SuppressFinalize (object).
02-09 13:46:10.264 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) System.Runtime.Loader.AssemblyLoadContext:InternalInitializeNativeALC 
(intptr,intptr,bool,bool).
02-09 13:46:10.265 29929 29929 D Mono    : AOT NOT FOUND: (wrapper managed-to-native) Interop/Logcat:__android_log_print 
(Interop/Logcat/LogLevel,string,string,string,intptr).
```
