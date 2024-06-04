WCF Annotation Store sample
===========================

Description
____________

This sample shows use of WCF service for sharing annotations. 
The WCF service is implemented as a self hosting service that stores annotations
in XmlStreamStores. The service can handle multiple XmlStreamStores that are 
identified by name. To each of them can be connected multiple clients. 
When the annotations in a particular XmlStreamStore change, the service notifies 
all the clients connected to this store for the change.
 The WCFAnnotationStore implements all the AnnotationStore functions by forwarding 
the calls to the WCF service. The annotations and resources are serialized with the 
help of temporary memory stream XmlStreamStore. In order to provide only one copy of
each annotation to the application, WCFAnnotationStore caches all locally used annotations.
It notifies the service when the application changes any of the cached annotations. 
It also listens to any change notifications from the service and reflects them 
on the cached annotations. That way any changes on annotations can be seen immediately
on all the applications using the same store. As a side effect StickyNotes can be used for 
online chat because there are no restrictions about who can edit the annotations.
One good extension would be restricting editing of the annotation to their author. This
can be achieved by appropriate styling of the StickyNotes. It will be subject of
another sample.

The implementation
__________________

The sample is implemented as VS 2005 solution with 5 projects:

1. WCFAnnotationStoreService - defines the WCF service interface for AnnotationStore
2. WCFAnnotationStoreHost - the WCF service hosting application that also contains service implementation.
3. WCFAnnotationStore - the WCFAnnotationStore implementation that works as a client to the WCFAnnotationStoreService. 
   The client-service communication is based on a duplex channel that allows callbacks from the service.
4. Helper - a helper class basically doing annotation serialization.
5. AnnotatedDocuments - a WPF application that allows loading different types of document in different types of viewers 
   and making annotations. This sample allows annotating FlowDocument in different types of flow DocumentViewers or
   XPS document in DocumentViewer.

How to build the sample
_______________________
Copy all the files and build the solution

How to run the sample
_____________________
1. Copy the content of AnnotatedDocuments\bin\debug(release) to as many client machines as you want. 
2. Copy cocoa.xps file to the binary location on the client machines
3. Copy the content of WCFAnnotationStoreHost\bin\debug(release) to the service hosting machine 
   (can be one of the client machines).
4. If your client and server machines are different you need to release ports 8080 and 80 through the firewall. 
   Go to ControlPanel\Security\Allow Program Through Windows Firewall -> Exceptions tab -> Add Port. 
   Enter some name(no matter what) and Port number = 8080. Click OK. Repeat the same for port 80. Repeat this on 
   all machines you want to use.
5. On the server machine from an elevated command prompt run WCFAnnotationsStoreHost.exe
6. On each client machine from an elevated command prompt run AnnotatedDocuments.exe <server machine name>. 
   You can run as many AnnotatedDocuments.exe applications as you want on each machine.
7. Choose menu commands.

Known issues
___________
Since the annotation changes are serialized on the server in case of simultaneous editing of the same annotation
from many clients, it is possible that some client representations get out of sync with the server store. It is
expected that in real applications there will be some restrictions about who can edit what.