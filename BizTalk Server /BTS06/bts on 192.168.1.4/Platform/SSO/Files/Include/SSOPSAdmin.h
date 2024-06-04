

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0366 */
/* Compiler settings for ssopsadmin.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __ssopsadmin_h__
#define __ssopsadmin_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __ISSOPSAdmin_FWD_DEFINED__
#define __ISSOPSAdmin_FWD_DEFINED__
typedef interface ISSOPSAdmin ISSOPSAdmin;
#endif 	/* __ISSOPSAdmin_FWD_DEFINED__ */


#ifndef __SSOPSAdmin_FWD_DEFINED__
#define __SSOPSAdmin_FWD_DEFINED__

#ifdef __cplusplus
typedef class SSOPSAdmin SSOPSAdmin;
#else
typedef struct SSOPSAdmin SSOPSAdmin;
#endif /* __cplusplus */

#endif 	/* __SSOPSAdmin_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

/* interface __MIDL_itf_ssopsadmin_0000 */
/* [local] */ 


/***************************************************************************
         Copyright (c) Microsoft Corporation, All rights reserved.          
***************************************************************************/



extern RPC_IF_HANDLE __MIDL_itf_ssopsadmin_0000_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_ssopsadmin_0000_v0_0_s_ifspec;

#ifndef __ISSOPSAdmin_INTERFACE_DEFINED__
#define __ISSOPSAdmin_INTERFACE_DEFINED__

/* interface ISSOPSAdmin */
/* [oleautomation][unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ISSOPSAdmin;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("C35718F9-C35C-4cd4-8978-2B4CE1792F1B")
    ISSOPSAdmin : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE AssignApplicationToAdapter( 
            /* [in] */ BSTR bstrApplicationName,
            /* [in] */ BSTR bstrAdapterName) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE RemoveApplicationFromAdapter( 
            /* [in] */ BSTR bstrApplicationName) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetApplicationsForAdapter( 
            /* [in] */ BSTR bstrAdapterName,
            /* [out] */ SAFEARRAY * *ppsaApplications) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE AssignAdapterToAdapterGroup( 
            /* [in] */ BSTR bstrAdapterName,
            /* [in] */ BSTR bstrAdapterGroupName) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE RemoveAdapterFromAdapterGroup( 
            /* [in] */ BSTR bstrAdapterName) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetAdaptersForAdapterGroup( 
            /* [in] */ BSTR bstrAdapterGroupName,
            /* [out] */ SAFEARRAY * *ppsaAdapters) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE SetAdapterProperties( 
            /* [in] */ BSTR bstrAdapterName,
            /* [in] */ IPropertyBag *ppbConfigInfo) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ClearNotificationQueues( 
            /* [in] */ BSTR bstrAdapterName) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ClearDampingTable( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISSOPSAdminVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISSOPSAdmin * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISSOPSAdmin * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISSOPSAdmin * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISSOPSAdmin * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISSOPSAdmin * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISSOPSAdmin * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISSOPSAdmin * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *AssignApplicationToAdapter )( 
            ISSOPSAdmin * This,
            /* [in] */ BSTR bstrApplicationName,
            /* [in] */ BSTR bstrAdapterName);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *RemoveApplicationFromAdapter )( 
            ISSOPSAdmin * This,
            /* [in] */ BSTR bstrApplicationName);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetApplicationsForAdapter )( 
            ISSOPSAdmin * This,
            /* [in] */ BSTR bstrAdapterName,
            /* [out] */ SAFEARRAY * *ppsaApplications);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *AssignAdapterToAdapterGroup )( 
            ISSOPSAdmin * This,
            /* [in] */ BSTR bstrAdapterName,
            /* [in] */ BSTR bstrAdapterGroupName);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *RemoveAdapterFromAdapterGroup )( 
            ISSOPSAdmin * This,
            /* [in] */ BSTR bstrAdapterName);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetAdaptersForAdapterGroup )( 
            ISSOPSAdmin * This,
            /* [in] */ BSTR bstrAdapterGroupName,
            /* [out] */ SAFEARRAY * *ppsaAdapters);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *SetAdapterProperties )( 
            ISSOPSAdmin * This,
            /* [in] */ BSTR bstrAdapterName,
            /* [in] */ IPropertyBag *ppbConfigInfo);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *ClearNotificationQueues )( 
            ISSOPSAdmin * This,
            /* [in] */ BSTR bstrAdapterName);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *ClearDampingTable )( 
            ISSOPSAdmin * This);
        
        END_INTERFACE
    } ISSOPSAdminVtbl;

    interface ISSOPSAdmin
    {
        CONST_VTBL struct ISSOPSAdminVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISSOPSAdmin_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISSOPSAdmin_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISSOPSAdmin_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISSOPSAdmin_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISSOPSAdmin_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISSOPSAdmin_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISSOPSAdmin_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISSOPSAdmin_AssignApplicationToAdapter(This,bstrApplicationName,bstrAdapterName)	\
    (This)->lpVtbl -> AssignApplicationToAdapter(This,bstrApplicationName,bstrAdapterName)

#define ISSOPSAdmin_RemoveApplicationFromAdapter(This,bstrApplicationName)	\
    (This)->lpVtbl -> RemoveApplicationFromAdapter(This,bstrApplicationName)

#define ISSOPSAdmin_GetApplicationsForAdapter(This,bstrAdapterName,ppsaApplications)	\
    (This)->lpVtbl -> GetApplicationsForAdapter(This,bstrAdapterName,ppsaApplications)

#define ISSOPSAdmin_AssignAdapterToAdapterGroup(This,bstrAdapterName,bstrAdapterGroupName)	\
    (This)->lpVtbl -> AssignAdapterToAdapterGroup(This,bstrAdapterName,bstrAdapterGroupName)

#define ISSOPSAdmin_RemoveAdapterFromAdapterGroup(This,bstrAdapterName)	\
    (This)->lpVtbl -> RemoveAdapterFromAdapterGroup(This,bstrAdapterName)

#define ISSOPSAdmin_GetAdaptersForAdapterGroup(This,bstrAdapterGroupName,ppsaAdapters)	\
    (This)->lpVtbl -> GetAdaptersForAdapterGroup(This,bstrAdapterGroupName,ppsaAdapters)

#define ISSOPSAdmin_SetAdapterProperties(This,bstrAdapterName,ppbConfigInfo)	\
    (This)->lpVtbl -> SetAdapterProperties(This,bstrAdapterName,ppbConfigInfo)

#define ISSOPSAdmin_ClearNotificationQueues(This,bstrAdapterName)	\
    (This)->lpVtbl -> ClearNotificationQueues(This,bstrAdapterName)

#define ISSOPSAdmin_ClearDampingTable(This)	\
    (This)->lpVtbl -> ClearDampingTable(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOPSAdmin_AssignApplicationToAdapter_Proxy( 
    ISSOPSAdmin * This,
    /* [in] */ BSTR bstrApplicationName,
    /* [in] */ BSTR bstrAdapterName);


void __RPC_STUB ISSOPSAdmin_AssignApplicationToAdapter_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOPSAdmin_RemoveApplicationFromAdapter_Proxy( 
    ISSOPSAdmin * This,
    /* [in] */ BSTR bstrApplicationName);


void __RPC_STUB ISSOPSAdmin_RemoveApplicationFromAdapter_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOPSAdmin_GetApplicationsForAdapter_Proxy( 
    ISSOPSAdmin * This,
    /* [in] */ BSTR bstrAdapterName,
    /* [out] */ SAFEARRAY * *ppsaApplications);


void __RPC_STUB ISSOPSAdmin_GetApplicationsForAdapter_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOPSAdmin_AssignAdapterToAdapterGroup_Proxy( 
    ISSOPSAdmin * This,
    /* [in] */ BSTR bstrAdapterName,
    /* [in] */ BSTR bstrAdapterGroupName);


void __RPC_STUB ISSOPSAdmin_AssignAdapterToAdapterGroup_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOPSAdmin_RemoveAdapterFromAdapterGroup_Proxy( 
    ISSOPSAdmin * This,
    /* [in] */ BSTR bstrAdapterName);


void __RPC_STUB ISSOPSAdmin_RemoveAdapterFromAdapterGroup_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOPSAdmin_GetAdaptersForAdapterGroup_Proxy( 
    ISSOPSAdmin * This,
    /* [in] */ BSTR bstrAdapterGroupName,
    /* [out] */ SAFEARRAY * *ppsaAdapters);


void __RPC_STUB ISSOPSAdmin_GetAdaptersForAdapterGroup_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOPSAdmin_SetAdapterProperties_Proxy( 
    ISSOPSAdmin * This,
    /* [in] */ BSTR bstrAdapterName,
    /* [in] */ IPropertyBag *ppbConfigInfo);


void __RPC_STUB ISSOPSAdmin_SetAdapterProperties_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOPSAdmin_ClearNotificationQueues_Proxy( 
    ISSOPSAdmin * This,
    /* [in] */ BSTR bstrAdapterName);


void __RPC_STUB ISSOPSAdmin_ClearNotificationQueues_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOPSAdmin_ClearDampingTable_Proxy( 
    ISSOPSAdmin * This);


void __RPC_STUB ISSOPSAdmin_ClearDampingTable_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISSOPSAdmin_INTERFACE_DEFINED__ */



#ifndef __SSOPSAdminLib_LIBRARY_DEFINED__
#define __SSOPSAdminLib_LIBRARY_DEFINED__

/* library SSOPSAdminLib */
/* [helpstring][version][uuid] */ 

#ifndef _SSO_FLAG
#define _SSO_FLAG
typedef /* [helpstring][uuid] */  DECLSPEC_UUID("DE580262-EE6C-4f9a-8BE2-81D2CE331270") 
enum SSO_FLAG
    {	SSO_FLAG_NONE	= 0,
	SSO_FLAG_REFRESH	= 0x1,
	SSO_FLAG_ENABLED	= 0x2,
	SSO_FLAG_SSO_WINDOWS_TO_EXTERNAL	= 0x4,
	SSO_FLAG_RUNTIME	= 0x4,
	SSO_FLAG_SSO_EXTERNAL_TO_WINDOWS	= 0x8,
	SSO_FLAG_SSO_VERIFY_EXTERNAL_CREDS	= 0x10,
	SSO_FLAG_ALLOW_TICKETS	= 0x20,
	SSO_FLAG_VALIDATE_TICKETS	= 0x40,
	SSO_FLAG_ADMIN_ENABLED	= 0x80,
	SSO_FLAG_READ_MODIFY_WRITE	= 0x100,
	SSO_FLAG_REPLAY	= 0x100,
	SSO_FLAG_PARTIAL_SYNC_FROM_WINDOWS_TO_DB	= 0x100,
	SSO_FLAG_PARTIAL_SYNC_FROM_EXTERNAL_TO_DB	= 0x200,
	SSO_FLAG_FULL_SYNC_FROM_WINDOWS_TO_EXTERNAL	= 0x400,
	SSO_FLAG_FULL_SYNC_FROM_EXTERNAL_TO_WINDOWS	= 0x800,
	SSO_FLAG_SYNC_VERIFY_EXTERNAL_CREDS	= 0x1000,
	SSO_FLAG_SYNC_PROVIDE_OLD_EXTERNAL_CREDS	= 0x2000,
	SSO_FLAG_SYNC_ALLOW_MAPPING_CONFLICTS	= 0x4000,
	SSO_FLAG_APP_USES_GROUP_MAPPING	= 0x10000,
	SSO_FLAG_APP_GROUP	= 0x10000,
	SSO_FLAG_APP_EXTERNAL_NAME_SAME	= 0x20000,
	SSO_FLAG_APP_ALLOW_LOCAL	= 0x40000,
	SSO_FLAG_APP_ADMIN_SAME	= 0x80000,
	SSO_FLAG_APP_CONFIG_STORE	= 0x100000,
	SSO_FLAG_APP_TICKET_TIMEOUT	= 0x200000,
	SSO_FLAG_APP_ADAPTER	= 0x400000,
	SSO_FLAG_APP_FILTER_BY_TYPE	= 0x1,
	SSO_FLAG_APP_SENSITIVE_INFO_REMOVED	= 0x80000000,
	SSO_FLAG_MAPPING_REQUIRES_WINDOWS_PASSWORD	= 0x1000000,
	SSO_FLAG_MAPPING_REQUIRES_EXTERNAL_CREDS	= 0x2000000,
	SSO_FLAG_MAPPING_ENABLE_AUDIT	= 0x4000000,
	SSO_FLAG_MAPPING_CONFIG_STORE	= 0x8000000,
	SSO_FLAG_MAPPING_ADMIN	= 0x10000000,
	SSO_FLAG_MAPPING_HOSTGROUP	= 0x20000000,
	SSO_FLAG_MAPPING_GROUP	= 0x40000000,
	SSO_FLAG_MAPPING_HIDE	= 0x80000000,
	SSO_FLAG_FIELD_INFO_MASK	= 0x10000000,
	SSO_FLAG_FIELD_INFO_SYNC	= 0x20000000,
	SSO_FLAG_SSO_DISABLE_CRED_CACHE	= 0x40000000
    } 	SSO_FLAG;

typedef /* [helpstring][uuid] */  DECLSPEC_UUID("0DF09E8B-B957-4ff6-8B29-B57918D61442") 
enum SSO_APP_TYPE
    {	SSO_APP_TYPE_NONE	= 0,
	SSO_APP_TYPE_INDIVIDUAL	= 0x1,
	SSO_APP_TYPE_GROUP	= 0x2,
	SSO_APP_TYPE_CONFIG_STORE	= 0x4,
	SSO_APP_TYPE_HOST_GROUP	= 0x8,
	SSO_APP_TYPE_PS_ADAPTER	= 0x10,
	SSO_APP_TYPE_PS_GROUP_ADAPTER	= 0x20
    } 	SSO_APP_TYPE;

#define	GLOBAL_FLAG_MASK	( SSO_FLAG_ENABLED | SSO_FLAG_SSO_WINDOWS_TO_EXTERNAL | SSO_FLAG_SSO_EXTERNAL_TO_WINDOWS | SSO_FLAG_SSO_VERIFY_EXTERNAL_CREDS | SSO_FLAG_ALLOW_TICKETS | SSO_FLAG_VALIDATE_TICKETS | SSO_FLAG_PARTIAL_SYNC_FROM_EXTERNAL_TO_DB | SSO_FLAG_FULL_SYNC_FROM_WINDOWS_TO_EXTERNAL | SSO_FLAG_FULL_SYNC_FROM_EXTERNAL_TO_WINDOWS | SSO_FLAG_SYNC_VERIFY_EXTERNAL_CREDS )

#define	SYNC_FLAG_MASK	( SSO_FLAG_PARTIAL_SYNC_FROM_EXTERNAL_TO_DB | SSO_FLAG_FULL_SYNC_FROM_WINDOWS_TO_EXTERNAL | SSO_FLAG_FULL_SYNC_FROM_EXTERNAL_TO_WINDOWS | SSO_FLAG_SYNC_VERIFY_EXTERNAL_CREDS | SSO_FLAG_SYNC_PROVIDE_OLD_EXTERNAL_CREDS | SSO_FLAG_SYNC_ALLOW_MAPPING_CONFLICTS )

#define	APP_FLAG_MASK	( SSO_FLAG_ENABLED | SSO_FLAG_SSO_WINDOWS_TO_EXTERNAL | SSO_FLAG_SSO_EXTERNAL_TO_WINDOWS | SSO_FLAG_ALLOW_TICKETS | SSO_FLAG_VALIDATE_TICKETS | SSO_FLAG_SSO_VERIFY_EXTERNAL_CREDS | SSO_FLAG_APP_USES_GROUP_MAPPING | SSO_FLAG_APP_EXTERNAL_NAME_SAME | SSO_FLAG_APP_ALLOW_LOCAL | SSO_FLAG_APP_ADMIN_SAME | SSO_FLAG_APP_CONFIG_STORE | SSO_FLAG_APP_TICKET_TIMEOUT | SSO_FLAG_APP_ADAPTER | SSO_FLAG_SSO_DISABLE_CRED_CACHE | SYNC_FLAG_MASK )

#define	DEFAULT_APP_FLAGS	( SSO_FLAG_SSO_WINDOWS_TO_EXTERNAL | SSO_FLAG_VALIDATE_TICKETS | SSO_FLAG_APP_TICKET_TIMEOUT )

#define	MAPPING_FLAG_MASK_IN	( SSO_FLAG_SSO_WINDOWS_TO_EXTERNAL | SSO_FLAG_SSO_EXTERNAL_TO_WINDOWS | SSO_FLAG_MAPPING_ENABLE_AUDIT )

#define	MAPPING_FLAG_MASK_OUT	( SSO_FLAG_ENABLED | SSO_FLAG_SSO_WINDOWS_TO_EXTERNAL | SSO_FLAG_SSO_EXTERNAL_TO_WINDOWS | SSO_FLAG_SSO_VERIFY_EXTERNAL_CREDS | SSO_FLAG_MAPPING_REQUIRES_WINDOWS_PASSWORD | SSO_FLAG_MAPPING_REQUIRES_EXTERNAL_CREDS | SSO_FLAG_MAPPING_ENABLE_AUDIT )

#define	FIELD_FLAG_MASK	( SSO_FLAG_FIELD_INFO_MASK | SSO_FLAG_FIELD_INFO_SYNC )

#endif _SSO_FLAG

EXTERN_C const IID LIBID_SSOPSAdminLib;

EXTERN_C const CLSID CLSID_SSOPSAdmin;

#ifdef __cplusplus

class DECLSPEC_UUID("626A947B-3F09-42fe-94AE-A31E6E8AACCF")
SSOPSAdmin;
#endif
#endif /* __SSOPSAdminLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

unsigned long             __RPC_USER  LPSAFEARRAY_UserSize(     unsigned long *, unsigned long            , LPSAFEARRAY * ); 
unsigned char * __RPC_USER  LPSAFEARRAY_UserMarshal(  unsigned long *, unsigned char *, LPSAFEARRAY * ); 
unsigned char * __RPC_USER  LPSAFEARRAY_UserUnmarshal(unsigned long *, unsigned char *, LPSAFEARRAY * ); 
void                      __RPC_USER  LPSAFEARRAY_UserFree(     unsigned long *, LPSAFEARRAY * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


