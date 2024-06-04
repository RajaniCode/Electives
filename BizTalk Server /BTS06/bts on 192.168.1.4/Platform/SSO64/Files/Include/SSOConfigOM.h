

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0366 */
/* Compiler settings for ssoconfigom.idl:
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

#ifndef __ssoconfigom_h__
#define __ssoconfigom_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __ISSOConfigOM_FWD_DEFINED__
#define __ISSOConfigOM_FWD_DEFINED__
typedef interface ISSOConfigOM ISSOConfigOM;
#endif 	/* __ISSOConfigOM_FWD_DEFINED__ */


#ifndef __ISSOConfigDB_FWD_DEFINED__
#define __ISSOConfigDB_FWD_DEFINED__
typedef interface ISSOConfigDB ISSOConfigDB;
#endif 	/* __ISSOConfigDB_FWD_DEFINED__ */


#ifndef __ISSOConfigSS_FWD_DEFINED__
#define __ISSOConfigSS_FWD_DEFINED__
typedef interface ISSOConfigSS ISSOConfigSS;
#endif 	/* __ISSOConfigSS_FWD_DEFINED__ */


#ifndef __SSOConfigOM_FWD_DEFINED__
#define __SSOConfigOM_FWD_DEFINED__

#ifdef __cplusplus
typedef class SSOConfigOM SSOConfigOM;
#else
typedef struct SSOConfigOM SSOConfigOM;
#endif /* __cplusplus */

#endif 	/* __SSOConfigOM_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

/* interface __MIDL_itf_ssoconfigom_0000 */
/* [local] */ 


/***************************************************************************
         Copyright (c) Microsoft Corporation, All rights reserved.          
***************************************************************************/

typedef /* [public] */ 
enum __MIDL___MIDL_itf_ssoconfigom_0000_0001
    {	SSO_STATUS_FLAG_NONE	= 0,
	SSO_STATUS_FLAG_ONLINE	= 0x1,
	SSO_STATUS_FLAG_SECRET_SERVER_RUNNING	= 0x2,
	SSO_STATUS_FLAG_PASSWORD_SYNC_LOADED	= 0x4,
	SSO_STATUS_FLAG_PASSWORD_SYNC_FOR_WINDOWS_RUNNING	= 0x8,
	SSO_STATUS_FLAG_PASSWORD_SYNC_FOR_ADAPTERS_RUNNING	= 0x10,
	SSO_STATUS_FLAG_CLUSTER	= 0x20,
	SSO_STATUS_FLAG_64BIT	= 0x40,
	SSO_STATUS_FLAG_SSL	= 0x80,
	SSO_STATUS_FLAG_CASE_SENSITIVE	= 0x100
    } 	SSO_STATUS_FLAG;



extern RPC_IF_HANDLE __MIDL_itf_ssoconfigom_0000_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_ssoconfigom_0000_v0_0_s_ifspec;

#ifndef __ISSOConfigOM_INTERFACE_DEFINED__
#define __ISSOConfigOM_INTERFACE_DEFINED__

/* interface ISSOConfigOM */
/* [oleautomation][unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ISSOConfigOM;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("5AC332CB-773F-4925-95FE-39CF2C670C24")
    ISSOConfigOM : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DiscoverServers( 
            /* [out] */ SAFEARRAY * *ppsaServers) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetServerStatus( 
            /* [in] */ LONG lFlagsIn,
            /* [out] */ BSTR *pbstrSSOServerName,
            /* [out] */ BSTR *pbstrSQLServer,
            /* [out] */ BSTR *pbstrSQLDatabase,
            /* [out] */ BSTR *pbstrServiceAccount,
            /* [out] */ BSTR *pbstrComputerNameCluster,
            /* [out] */ BSTR *pbstrComputerNameNode,
            /* [out] */ LONG *plEventCountInformational,
            /* [out] */ LONG *plEventCountWarning,
            /* [out] */ LONG *plEventCountError,
            /* [out] */ LONG *plVersionInfoM,
            /* [out] */ LONG *plVersionInfoL,
            /* [out] */ LONG *plAuditLevelN,
            /* [out] */ LONG *plAuditLevelP,
            /* [out] */ LONG *plPasswordSyncAge,
            /* [out] */ LONG *plStatusFlags) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISSOConfigOMVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISSOConfigOM * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISSOConfigOM * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISSOConfigOM * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISSOConfigOM * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISSOConfigOM * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISSOConfigOM * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISSOConfigOM * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DiscoverServers )( 
            ISSOConfigOM * This,
            /* [out] */ SAFEARRAY * *ppsaServers);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetServerStatus )( 
            ISSOConfigOM * This,
            /* [in] */ LONG lFlagsIn,
            /* [out] */ BSTR *pbstrSSOServerName,
            /* [out] */ BSTR *pbstrSQLServer,
            /* [out] */ BSTR *pbstrSQLDatabase,
            /* [out] */ BSTR *pbstrServiceAccount,
            /* [out] */ BSTR *pbstrComputerNameCluster,
            /* [out] */ BSTR *pbstrComputerNameNode,
            /* [out] */ LONG *plEventCountInformational,
            /* [out] */ LONG *plEventCountWarning,
            /* [out] */ LONG *plEventCountError,
            /* [out] */ LONG *plVersionInfoM,
            /* [out] */ LONG *plVersionInfoL,
            /* [out] */ LONG *plAuditLevelN,
            /* [out] */ LONG *plAuditLevelP,
            /* [out] */ LONG *plPasswordSyncAge,
            /* [out] */ LONG *plStatusFlags);
        
        END_INTERFACE
    } ISSOConfigOMVtbl;

    interface ISSOConfigOM
    {
        CONST_VTBL struct ISSOConfigOMVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISSOConfigOM_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISSOConfigOM_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISSOConfigOM_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISSOConfigOM_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISSOConfigOM_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISSOConfigOM_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISSOConfigOM_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISSOConfigOM_DiscoverServers(This,ppsaServers)	\
    (This)->lpVtbl -> DiscoverServers(This,ppsaServers)

#define ISSOConfigOM_GetServerStatus(This,lFlagsIn,pbstrSSOServerName,pbstrSQLServer,pbstrSQLDatabase,pbstrServiceAccount,pbstrComputerNameCluster,pbstrComputerNameNode,plEventCountInformational,plEventCountWarning,plEventCountError,plVersionInfoM,plVersionInfoL,plAuditLevelN,plAuditLevelP,plPasswordSyncAge,plStatusFlags)	\
    (This)->lpVtbl -> GetServerStatus(This,lFlagsIn,pbstrSSOServerName,pbstrSQLServer,pbstrSQLDatabase,pbstrServiceAccount,pbstrComputerNameCluster,pbstrComputerNameNode,plEventCountInformational,plEventCountWarning,plEventCountError,plVersionInfoM,plVersionInfoL,plAuditLevelN,plAuditLevelP,plPasswordSyncAge,plStatusFlags)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOConfigOM_DiscoverServers_Proxy( 
    ISSOConfigOM * This,
    /* [out] */ SAFEARRAY * *ppsaServers);


void __RPC_STUB ISSOConfigOM_DiscoverServers_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOConfigOM_GetServerStatus_Proxy( 
    ISSOConfigOM * This,
    /* [in] */ LONG lFlagsIn,
    /* [out] */ BSTR *pbstrSSOServerName,
    /* [out] */ BSTR *pbstrSQLServer,
    /* [out] */ BSTR *pbstrSQLDatabase,
    /* [out] */ BSTR *pbstrServiceAccount,
    /* [out] */ BSTR *pbstrComputerNameCluster,
    /* [out] */ BSTR *pbstrComputerNameNode,
    /* [out] */ LONG *plEventCountInformational,
    /* [out] */ LONG *plEventCountWarning,
    /* [out] */ LONG *plEventCountError,
    /* [out] */ LONG *plVersionInfoM,
    /* [out] */ LONG *plVersionInfoL,
    /* [out] */ LONG *plAuditLevelN,
    /* [out] */ LONG *plAuditLevelP,
    /* [out] */ LONG *plPasswordSyncAge,
    /* [out] */ LONG *plStatusFlags);


void __RPC_STUB ISSOConfigOM_GetServerStatus_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISSOConfigOM_INTERFACE_DEFINED__ */


#ifndef __ISSOConfigDB_INTERFACE_DEFINED__
#define __ISSOConfigDB_INTERFACE_DEFINED__

/* interface ISSOConfigDB */
/* [oleautomation][unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ISSOConfigDB;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("EF1D1B7A-A661-42b0-8154-6B0F3A2FF5C0")
    ISSOConfigDB : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetDBInfo( 
            /* [in] */ BSTR bstrSQLServer,
            /* [in] */ BSTR bstrSQLDatabase,
            /* [out] */ VARIANT_BOOL *pfExists,
            /* [out] */ VARIANT_BOOL *pfIsConfigured,
            /* [out] */ VARIANT_BOOL *pfNeedsUpgrade,
            /* [out] */ BSTR *pbstrSecretServer,
            /* [out] */ BSTR *pbstrSSOAdminAccount,
            /* [out] */ BSTR *pbstrSSOAffilateAdminAccount) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CreateDatabase( 
            /* [in] */ BSTR bstrSQLServer,
            /* [in] */ BSTR bstrSQLDatabase,
            /* [in] */ VARIANT_BOOL fConfigureOnly,
            /* [in] */ BSTR bstrSecretServer,
            /* [in] */ BSTR bstrSSOAdminAccount,
            /* [in] */ BSTR bstrSSOAffilateAdminAccount) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE UpgradeDatabase( 
            /* [in] */ BSTR bstrSQLServer,
            /* [in] */ BSTR bstrSQLDatabase) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISSOConfigDBVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISSOConfigDB * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISSOConfigDB * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISSOConfigDB * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISSOConfigDB * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISSOConfigDB * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISSOConfigDB * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISSOConfigDB * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetDBInfo )( 
            ISSOConfigDB * This,
            /* [in] */ BSTR bstrSQLServer,
            /* [in] */ BSTR bstrSQLDatabase,
            /* [out] */ VARIANT_BOOL *pfExists,
            /* [out] */ VARIANT_BOOL *pfIsConfigured,
            /* [out] */ VARIANT_BOOL *pfNeedsUpgrade,
            /* [out] */ BSTR *pbstrSecretServer,
            /* [out] */ BSTR *pbstrSSOAdminAccount,
            /* [out] */ BSTR *pbstrSSOAffilateAdminAccount);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CreateDatabase )( 
            ISSOConfigDB * This,
            /* [in] */ BSTR bstrSQLServer,
            /* [in] */ BSTR bstrSQLDatabase,
            /* [in] */ VARIANT_BOOL fConfigureOnly,
            /* [in] */ BSTR bstrSecretServer,
            /* [in] */ BSTR bstrSSOAdminAccount,
            /* [in] */ BSTR bstrSSOAffilateAdminAccount);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *UpgradeDatabase )( 
            ISSOConfigDB * This,
            /* [in] */ BSTR bstrSQLServer,
            /* [in] */ BSTR bstrSQLDatabase);
        
        END_INTERFACE
    } ISSOConfigDBVtbl;

    interface ISSOConfigDB
    {
        CONST_VTBL struct ISSOConfigDBVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISSOConfigDB_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISSOConfigDB_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISSOConfigDB_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISSOConfigDB_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISSOConfigDB_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISSOConfigDB_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISSOConfigDB_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISSOConfigDB_GetDBInfo(This,bstrSQLServer,bstrSQLDatabase,pfExists,pfIsConfigured,pfNeedsUpgrade,pbstrSecretServer,pbstrSSOAdminAccount,pbstrSSOAffilateAdminAccount)	\
    (This)->lpVtbl -> GetDBInfo(This,bstrSQLServer,bstrSQLDatabase,pfExists,pfIsConfigured,pfNeedsUpgrade,pbstrSecretServer,pbstrSSOAdminAccount,pbstrSSOAffilateAdminAccount)

#define ISSOConfigDB_CreateDatabase(This,bstrSQLServer,bstrSQLDatabase,fConfigureOnly,bstrSecretServer,bstrSSOAdminAccount,bstrSSOAffilateAdminAccount)	\
    (This)->lpVtbl -> CreateDatabase(This,bstrSQLServer,bstrSQLDatabase,fConfigureOnly,bstrSecretServer,bstrSSOAdminAccount,bstrSSOAffilateAdminAccount)

#define ISSOConfigDB_UpgradeDatabase(This,bstrSQLServer,bstrSQLDatabase)	\
    (This)->lpVtbl -> UpgradeDatabase(This,bstrSQLServer,bstrSQLDatabase)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOConfigDB_GetDBInfo_Proxy( 
    ISSOConfigDB * This,
    /* [in] */ BSTR bstrSQLServer,
    /* [in] */ BSTR bstrSQLDatabase,
    /* [out] */ VARIANT_BOOL *pfExists,
    /* [out] */ VARIANT_BOOL *pfIsConfigured,
    /* [out] */ VARIANT_BOOL *pfNeedsUpgrade,
    /* [out] */ BSTR *pbstrSecretServer,
    /* [out] */ BSTR *pbstrSSOAdminAccount,
    /* [out] */ BSTR *pbstrSSOAffilateAdminAccount);


void __RPC_STUB ISSOConfigDB_GetDBInfo_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOConfigDB_CreateDatabase_Proxy( 
    ISSOConfigDB * This,
    /* [in] */ BSTR bstrSQLServer,
    /* [in] */ BSTR bstrSQLDatabase,
    /* [in] */ VARIANT_BOOL fConfigureOnly,
    /* [in] */ BSTR bstrSecretServer,
    /* [in] */ BSTR bstrSSOAdminAccount,
    /* [in] */ BSTR bstrSSOAffilateAdminAccount);


void __RPC_STUB ISSOConfigDB_CreateDatabase_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOConfigDB_UpgradeDatabase_Proxy( 
    ISSOConfigDB * This,
    /* [in] */ BSTR bstrSQLServer,
    /* [in] */ BSTR bstrSQLDatabase);


void __RPC_STUB ISSOConfigDB_UpgradeDatabase_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISSOConfigDB_INTERFACE_DEFINED__ */


#ifndef __ISSOConfigSS_INTERFACE_DEFINED__
#define __ISSOConfigSS_INTERFACE_DEFINED__

/* interface ISSOConfigSS */
/* [oleautomation][unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ISSOConfigSS;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("92A8E726-A83B-4ef6-8D77-197558227B0D")
    ISSOConfigSS : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GenerateSecret( 
            /* [in] */ BSTR bstrBackupFile,
            /* [in] */ BSTR bstrFilePassword,
            /* [in] */ BSTR bstrFilePasswordReminder) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE BackupSecret( 
            /* [in] */ BSTR bstrBackupFile,
            /* [in] */ BSTR bstrFilePassword,
            /* [in] */ BSTR bstrFilePasswordReminder) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetFilePasswordReminder( 
            /* [in] */ BSTR bstrRestoreFile,
            /* [out] */ BSTR *pbstrFilePasswordReminder) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE RestoreSecret( 
            /* [in] */ BSTR bstrRestoreFile,
            /* [in] */ BSTR bstrFilePassword) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISSOConfigSSVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISSOConfigSS * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISSOConfigSS * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISSOConfigSS * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISSOConfigSS * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISSOConfigSS * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISSOConfigSS * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISSOConfigSS * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GenerateSecret )( 
            ISSOConfigSS * This,
            /* [in] */ BSTR bstrBackupFile,
            /* [in] */ BSTR bstrFilePassword,
            /* [in] */ BSTR bstrFilePasswordReminder);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *BackupSecret )( 
            ISSOConfigSS * This,
            /* [in] */ BSTR bstrBackupFile,
            /* [in] */ BSTR bstrFilePassword,
            /* [in] */ BSTR bstrFilePasswordReminder);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetFilePasswordReminder )( 
            ISSOConfigSS * This,
            /* [in] */ BSTR bstrRestoreFile,
            /* [out] */ BSTR *pbstrFilePasswordReminder);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *RestoreSecret )( 
            ISSOConfigSS * This,
            /* [in] */ BSTR bstrRestoreFile,
            /* [in] */ BSTR bstrFilePassword);
        
        END_INTERFACE
    } ISSOConfigSSVtbl;

    interface ISSOConfigSS
    {
        CONST_VTBL struct ISSOConfigSSVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISSOConfigSS_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISSOConfigSS_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISSOConfigSS_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISSOConfigSS_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISSOConfigSS_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISSOConfigSS_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISSOConfigSS_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISSOConfigSS_GenerateSecret(This,bstrBackupFile,bstrFilePassword,bstrFilePasswordReminder)	\
    (This)->lpVtbl -> GenerateSecret(This,bstrBackupFile,bstrFilePassword,bstrFilePasswordReminder)

#define ISSOConfigSS_BackupSecret(This,bstrBackupFile,bstrFilePassword,bstrFilePasswordReminder)	\
    (This)->lpVtbl -> BackupSecret(This,bstrBackupFile,bstrFilePassword,bstrFilePasswordReminder)

#define ISSOConfigSS_GetFilePasswordReminder(This,bstrRestoreFile,pbstrFilePasswordReminder)	\
    (This)->lpVtbl -> GetFilePasswordReminder(This,bstrRestoreFile,pbstrFilePasswordReminder)

#define ISSOConfigSS_RestoreSecret(This,bstrRestoreFile,bstrFilePassword)	\
    (This)->lpVtbl -> RestoreSecret(This,bstrRestoreFile,bstrFilePassword)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOConfigSS_GenerateSecret_Proxy( 
    ISSOConfigSS * This,
    /* [in] */ BSTR bstrBackupFile,
    /* [in] */ BSTR bstrFilePassword,
    /* [in] */ BSTR bstrFilePasswordReminder);


void __RPC_STUB ISSOConfigSS_GenerateSecret_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOConfigSS_BackupSecret_Proxy( 
    ISSOConfigSS * This,
    /* [in] */ BSTR bstrBackupFile,
    /* [in] */ BSTR bstrFilePassword,
    /* [in] */ BSTR bstrFilePasswordReminder);


void __RPC_STUB ISSOConfigSS_BackupSecret_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOConfigSS_GetFilePasswordReminder_Proxy( 
    ISSOConfigSS * This,
    /* [in] */ BSTR bstrRestoreFile,
    /* [out] */ BSTR *pbstrFilePasswordReminder);


void __RPC_STUB ISSOConfigSS_GetFilePasswordReminder_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISSOConfigSS_RestoreSecret_Proxy( 
    ISSOConfigSS * This,
    /* [in] */ BSTR bstrRestoreFile,
    /* [in] */ BSTR bstrFilePassword);


void __RPC_STUB ISSOConfigSS_RestoreSecret_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISSOConfigSS_INTERFACE_DEFINED__ */



#ifndef __SSOConfigOMLib_LIBRARY_DEFINED__
#define __SSOConfigOMLib_LIBRARY_DEFINED__

/* library SSOConfigOMLib */
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

EXTERN_C const IID LIBID_SSOConfigOMLib;

EXTERN_C const CLSID CLSID_SSOConfigOM;

#ifdef __cplusplus

class DECLSPEC_UUID("2A40B78A-5C0B-4f39-A2CB-6D9AF29ECA37")
SSOConfigOM;
#endif
#endif /* __SSOConfigOMLib_LIBRARY_DEFINED__ */

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


