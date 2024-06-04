//
//  CSSwizzler.m
//  EnumeratePhotos
//
//  Created by Eric Allam on 3/6/13.
//  Copyright (c) 2013 Code School. All rights reserved.
//

#import "CSSwizzler.h"
#import <objc/message.h>
#import <objc/runtime.h>

@implementation CSSwizzler

+(BOOL)swizzleClass:(id)cls
      replaceMethod:(SEL)origSelector
 withImplementation:(IMP)replacement
            storeIn:(IMP *)store;
{
    IMP imp = NULL;
    Method method = class_getInstanceMethod(cls, origSelector);
    if (method) {
        const char *type = method_getTypeEncoding(method);
        imp = class_replaceMethod(cls, origSelector, replacement, type);
        if (!imp) {
            imp = method_getImplementation(method);
        }
    }
    if (imp && store) { *store = imp; }
    return (imp != NULL);
}

+(BOOL)swizzleClass:(id)cls
 replaceClassMethod:(SEL)origSelector
    withImplementation:(IMP)replacement
            storeIn:(IMP *)store;
{
    IMP imp = NULL;
    Method method = class_getClassMethod(cls, origSelector);
    if (method) {
        const char *type = method_getTypeEncoding(method);
        imp = class_replaceMethod(object_getClass(cls), origSelector, replacement, type);
        if (!imp) {
            imp = method_getImplementation(method);
        }
    }
    if (imp && store) { *store = imp; }
    return (imp != NULL);
}

+(void)swizzleClass:(id)cls
 replaceClassMethod:(SEL)origMethodSelector
         withMethod:(SEL)replacementMethodSelector;
{
    Method origMethod = nil, altMethod = nil;
    origMethod = class_getClassMethod(cls, origMethodSelector);
    altMethod = class_getClassMethod(cls, replacementMethodSelector);
    method_exchangeImplementations(origMethod, altMethod);
}

+(void)swizzleClass:(id)cls
      replaceMethod:(SEL)origMethodSelector
         withMethod:(SEL)replacementMethodSelector;
{
    Method origMethod = nil, altMethod = nil;
    origMethod = class_getInstanceMethod(cls, origMethodSelector);
    altMethod = class_getInstanceMethod(cls, replacementMethodSelector);
    method_exchangeImplementations(origMethod, altMethod);
}

+(void)swizzleClassOfInstance:(id)inst
                replaceMethod:(SEL)origMethodSelector
                   withMethod:(SEL)replacementMethodSelector;
{
    const char *str = [[[inst class] description] UTF8String];
    Class cls = objc_getClass(str);
    Method origMethod = nil, altMethod = nil;
    origMethod = class_getInstanceMethod(cls, origMethodSelector);
    altMethod = class_getInstanceMethod(cls, replacementMethodSelector);
    method_exchangeImplementations(origMethod, altMethod);
}
@end
