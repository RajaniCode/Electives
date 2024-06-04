//
//  GMSServices+ZSwizzles.m
//  Level1-2-SettingUpAnApiKey
//
//  Created by Jon Friskics on 3/12/14.
//  Copyright (c) 2014 Jon Friskics. All rights reserved.
//

#import "GMSServices+ZSwizzles.h"
#import "CSSwizzler.h"
#import <objc/runtime.h>
#import "AppDelegate+TestAdditions.h"

@implementation GMSServices (ZSwizzles)

static BOOL CustomProvideApiKey(id, SEL, NSString *);

static BOOL (*CustomProvideApiKeyIMP)(id, SEL, NSString *);

static BOOL CustomProvideApiKey(id self, SEL _cmd, NSString *apiKey){
  AppDelegate *appDelegate = [[UIApplication sharedApplication] delegate];
  
  BOOL success = NO;
  
  if([appDelegate.apiKeySuccess integerValue] == 0) {
    appDelegate.apiKey = apiKey;
    appDelegate.apiKeySuccess = @([appDelegate.apiKeySuccess integerValue] + 1);
  } else {
    success = CustomProvideApiKeyIMP(self, _cmd, apiKey);
  }
  
  return success;
}

+ (void)load
{
  [CSSwizzler swizzleClass:[[NSBundle mainBundle] classNamed:@"GMSServices"]
        replaceClassMethod:@selector(provideAPIKey:)
        withImplementation:(IMP)CustomProvideApiKey
                   storeIn:(IMP *)&CustomProvideApiKeyIMP];
}

@end
