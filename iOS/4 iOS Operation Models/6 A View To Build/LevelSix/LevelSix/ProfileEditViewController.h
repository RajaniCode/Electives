#import <UIKit/UIKit.h>
#import "User.h"

@interface ProfileEditViewController : UIViewController <UITextFieldDelegate>

@property (strong, nonatomic) User *user;

@property (strong, nonatomic) UITextField *locationField;

- (void)saveLocation;
- (void)saveUserWhenClosing;

@end