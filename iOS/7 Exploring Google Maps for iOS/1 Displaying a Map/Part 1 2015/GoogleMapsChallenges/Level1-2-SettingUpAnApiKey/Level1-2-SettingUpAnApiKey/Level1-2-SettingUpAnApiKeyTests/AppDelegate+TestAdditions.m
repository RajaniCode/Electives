#import "AppDelegate+TestAdditions.h"
#import <objc/objc-runtime.h>

@implementation AppDelegate (TestAdditions)

- (void)setApiKey:(NSString *)apiKey
{
  objc_setAssociatedObject(self, @selector(apiKey), apiKey, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSString *)apiKey
{
  return objc_getAssociatedObject(self, @selector(apiKey));
}

- (void)setApiKeySuccess:(NSNumber *)apiKeySuccess
{
  objc_setAssociatedObject(self, @selector(apiKeySuccess), apiKeySuccess, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

- (NSNumber *)apiKeySuccess
{
  return objc_getAssociatedObject(self, @selector(apiKeySuccess));
}

@end
 