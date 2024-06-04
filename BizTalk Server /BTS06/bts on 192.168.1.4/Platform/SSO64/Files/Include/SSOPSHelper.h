

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0366 */
/* Compiler settings for ssopshelper.idl:
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

#ifndef __ssopshelper_h__
#define __ssopshelper_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __ISSONotification_FWD_DEFINED__
#define __ISSONotification_FWD_DEFINED__
typedef interface ISSONotification ISSONotification;
#endif 	/* __ISSONotification_FWD_DEFINED__ */


#ifndef __SSOPSHelper_FWD_DEFINED__
#define __SSOPSHelper_FWD_DEFINED__

#ifdef __cplusplus
typedef class SSOPSHelper SSOPSHelper;
#else
typedef struct SSOPSHelper SSOPSHelper;
#endif /* __cplusplus */

#endif 	/* __SSOPSHelper_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

/* interface __MIDL_itf_ssopshelper_0000 */
/* [local] */ 


/***************************************************************************
         Copyright (c) Microsoft Corporation, All rights reserved.          
***************************************************************************/

typedef /* [public] */ 
enum __MIDL___MIDL_itf_ssopshelper_0000_0001
    {	SSO_NOTIFICATION_FLAG_NONE	= 0,
	SSO_NOTIFICATION_FLAG_ADMIN_CHANGE	= 0x1,
	SSO_NOTIFICATION_FLAG_TEST	= 0x8,
	SSO_NOTIFICATION_FLAG_AUDIT	= 0x10,
	SSO_NOTIFICATION_FLAG_WINDOWS	= 0x20,
	SSO_NOTIFICATION_FLAG_WAIT	= 0x40,
	SSO_NOTIFICATION_FLAG_SEND_ONLY	= 0x80
    } 	SSO_NOTIFICATION_FLAG;

typedef /* [public][public][public][public][public] */ 
enum __MIDL___MIDL_itf_ssopshelper_0000_0002
    {	SSO_NOTIFICATION_TYPE_NONE	= 0,
	SSO_NOTIFICATION_TYPE_SHUTDOWN	= 0x1,
	SSO_NOTIFICATION_TYPE_SHUTDOWN_COMPLETE	= 0x2,
	SSO_NOTIFICATION_TYPE_PASSWORD_CHANGE	= 0x3,
	SSO_NOTIFICATION_TYPE_PASSWORD_CHANGE_COMPLETE	= 0x4,
	SSO_NOTIFICATION_TYPE_PASSWORD_EXPIRED	= 0x5,
	SSO_NOTIFICATION_TYPE_STATUS_REQUEST	= 0x6,
	SSO_NOTIFICATION_TYPE_STATUS_ONLINE	= 0x7,
	SSO_NOTIFICATION_TYPE_STATUS_OFFLINE	= 0x8,
	SSO_NOTIFICATION_TYPE_PROPERTIES_CHANGED	= 0x9,
	SSO_NOTIFICATION_TYPE_ADAPTERS_IN_GROUP	= 0x1000,
	SSO_NOTIFICATION_TYPE_ADD_ADAPTER	= 0x1001,
	SSO_NOTIFICATION_TYPE_DELETE_ADAPTER	= 0x1002
    } 	SSO_NOTIFICATION_TYPE;

typedef struct SExternalAccount
    {
    BSTR bstrExternalAccount;
    } 	SExternalAccount;

typedef struct SPasswordChange
    {
    BSTR bstrExternalAccount;
    BSTR bstrNewExternalPassword;
    BSTR bstrOldExternalPassword;
    ULONGLONG ullTimestamp;
    } 	SPasswordChange;

typedef struct SPasswordChangeComplete
    {
    GUID guidTrackingId;
    ULONGLONG ullErrorCode;
    BSTR bstrErrorMessage;
    } 	SPasswordChangeComplete;

typedef struct SStatus
    {
    ULONGLONG ullErrorCode;
    BSTR bstrErrorMessage;
    } 	SStatus;

typedef struct SAdaptersInGroup
    {
    SAFEARRAY * psaAdapters;
    } 	SAdaptersInGroup;

typedef struct SChangeAdapter
    {
    BSTR bstrAdapterName;
    } 	SChangeAdapter;

typedef struct SSendNotification
    {
    SSO_NOTIFICATION_TYPE NotificationType;
    ULONG ulNotificationFlags;
    /* [switch_is] */ /* [switch_type] */ union 
        {
        /* [case()] */ SPasswordChange PasswordChange;
        /* [case()] */ SPasswordChangeComplete PasswordChangeComplete;
        /* [case()] */ SStatus StatusInfo;
        /* [case()] */ SExternalAccount ExpiredAccount;
        /* [case()] */  /* Empty union arm */ 
        } 	Union;
    } 	SSendNotification;

typedef struct SReceiveNotification
    {
    SSO_NOTIFICATION_TYPE NotificationType;
    ULONG ulNotificationFlags;
    /* [switch_is] */ /* [switch_type] */ union 
        {
        /* [case()] */ SPasswordChange PasswordChange;
        /* [case()] */ SPasswordChangeComplete PasswordChangeComplete;
        /* [case()] */ SStatus StatusInfo;
        /* [case()] */ SExternalAccount ExpiredAccount;
        /* [case()] */  /* Empty union arm */ 
        /* [case()] */ SAdaptersInGroup Adapters;
        /* [case()] */ SChangeAdapter Adapter;
        } 	Union;
    } 	SReceiveNotification;



extern RPC_IF_HANDLE __MIDL_itf_ssopshelper_0000_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_ssopshelper_0000_v0_0_s_ifspec;

#ifndef __ISSONotification_INTERFACE_DEFINED__
#define __ISSONotification_INTERFACE_DEFINED__

/* interface ISSONotification */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_ISSONotification;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("F71C4670-9D6D-4c7d-97F5-CB2156F6208C")
    ISSONotification : public IUnknown
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE InitializeAdapter( 
            /* [in] */ BSTR bstrAdapterName,
            /* [in] */ ULONG ulFlags,
            /* [out] */ ULONGLONG *phNotifyEvent,
            /* [out] */ GUID *pguidTrackingId) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE SendNotification( 
            /* [in] */ SSendNotification SendNotification,
            /* [out] */ GUID *pguidTrackingId) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ReceiveNotification( 
            /* [in] */ ULONG ulNotificationFlagsIn,
            /* [out][in] */ SReceiveNotification *pReceiveNotification,
            /* [out] */ GUID *pguidTrackingId) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ShutdownAdapter( 
            /* [out] */ GUID *pguidTrackingId) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISSONotificationVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISSONotification * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISSONotification * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISSONotification * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE *InitializeAdapter )( 
            ISSONotification * This,
            /* [in] */ BSTR bstrAdapterName,
            /* [in] */ ULONG ulFlags,
            /* [out] */ ULONGLONG *phNotifyEvent,
            /* [out] */ GUID *pguidTrackingId);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE *SendNotification )( 
            ISSONotification * This,
            /* [in] */ SSendNotification SendNotification,
            /* [out] */ GUID *pguidTrackingId);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE *ReceiveNotification )( 
            ISSONotification * This,
            /* [in] */ ULONG ulNotificationFlagsIn,
            /* [out][in] */ SReceiveNotification *pReceiveNotification,
            /* [out] */ GUID *pguidTrackingId);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE *ShutdownAdapter )( 
            ISSONotification * This,
            /* [out] */ GUID *pguidTrackingId);
        
        END_INTERFACE
    } ISSONotificationVtbl;

    interface ISSONotification
    {
        CONST_VTBL struct ISSONotificationVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISSONotification_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISSONotification_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISSONotification_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISSONotification_InitializeAdapter(This,bstrAdapterName,ulFlags,phNotifyEvent,pguidTrackingId)	\
    (This)->lpVtbl -> InitializeAdapter(This,bstrAdapterName,ulFlags,phNotifyEvent,pguidTrackingId)

#define ISSONotification_SendNotification(This,SendNotification,pguidTrackingId)	\
    (This)->lpVtbl -> SendNotification(This,SendNotification,pguidTrackingId)

#define ISSONotification_ReceiveNotification(This,ulNotificationFlagsIn,pReceiveNotification,pguidTrackingId)	\
    (This)->lpVtbl -> ReceiveNotification(This,ulNotificationFlagsIn,pReceiveNotification,pguidTrackingId)

#define ISSONotification_ShutdownAdapter(This,pguidTrackingId)	\
    (This)->lpVtbl -> ShutdownAdapter(This,pguidTrackingId)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISSONotification_InitializeAdapter_Proxy( 
    ISSONotification * This,
    /* [in] */ BSTR bstrAdapterName,
    /* [in] */ ULONG ulFlags,
    /* [out] */ ULONGLONG *phNotifyEvent,
    /* [out] */ GUID *pguidTrackingId);


void __RPC_STUB ISSONotification_InitializeAdapter_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISSONotification_SendNotification_Proxy( 
    ISSONotification * This,
    /* [in] */ SSendNotification SendNotification,
    /* [out] */ GUID *pguidTrackingId);


void __RPC_STUB ISSONotification_SendNotification_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISSONotification_ReceiveNotification_Proxy( 
    ISSONotification * This,
    /* [in] */ ULONG ulNotificationFlagsIn,
    /* [out][in] */ SReceiveNotification *pReceiveNotification,
    /* [out] */ GUID *pguidTrackingId);


void __RPC_STUB ISSONotification_ReceiveNotification_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE ISSONotification_ShutdownAdapter_Proxy( 
    ISSONotification * This,
    /* [out] */ GUID *pguidTrackingId);


void __RPC_STUB ISSONotification_ShutdownAdapter_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISSONotification_INTERFACE_DEFINED__ */



#ifndef __SSOPSHelperLib_LIBRARY_DEFINED__
#define __SSOPSHelperLib_LIBRARY_DEFINED__

/* library SSOPSHelperLib */
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

EXTERN_C const IID LIBID_SSOPSHelperLib;

EXTERN_C const CLSID CLSID_SSOPSHelper;

#ifdef __cplusplus

class DECLSPEC_UUID("E7E0668E-8C27-46a9-8916-39EFA52AC2F5")
SSOPSHelper;
#endif
#endif /* __SSOPSHelperLib_LIBRARY_DEFINED__ */

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


