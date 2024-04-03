//#pragma once
//#ifndef __IDMSOperationsEvents_H_INCLUDED__
//#define __IDMSOperationsEvents_H_INCLUDED__
//
//#include <unknwn.h>
//#include <wtypes.h>
//
////{99e1fbad-adab-49cf-abb1-b147b667ab86}
//DEFINE_GUID(IID_IDMSOperationsEvents,
//	0x99e1fbad, 0xadab, 0x49cf, 0xab, 0xb1, 0xb1, 0x47, 0xb6, 0x67, 0xab, 0x86);
//
//interface IOperationsEvents : public IUnknown
//{
//public:
//	virtual HRESULT STDMETHODCALLTYPE OnFileCreated(BSTR filePath) = 0;
//	virtual HRESULT STDMETHODCALLTYPE OnFileDeleted(BSTR filePath) = 0;
//	virtual HRESULT STDMETHODCALLTYPE OnFileRead(BSTR filePath, BSTR content) = 0;
//	virtual HRESULT STDMETHODCALLTYPE OnFileUpdated(BSTR filePath, BSTR newContent) = 0;
//	virtual HRESULT STDMETHODCALLTYPE OnFileMoved(BSTR originalFilePath, BSTR newFilePath) = 0;
//
//	virtual HRESULT STDMETHODCALLTYPE OnFolderCreated(BSTR folderPath) = 0;
//	virtual HRESULT STDMETHODCALLTYPE OnFolderDeleted(BSTR folderPath) = 0;
//	virtual HRESULT STDMETHODCALLTYPE OnFolderMoved(BSTR originalFilePath, BSTR newFilePath) = 0;
//	virtual HRESULT STDMETHODCALLTYPE OnFolderRenamed(BSTR originalFilePath, BSTR newFolderName) = 0;
//	virtual HRESULT STDMETHODCALLTYPE OnFolderOpened(BSTR folderPath) = 0;
//};
//
//#endif