#import "StreetViewVC.h"

@interface StreetViewVC ()

@end

@implementation StreetViewVC

- (id)initWithNibName:(NSString *)nibNameOrNil
               bundle:(NSBundle *)nibBundleOrNil {
  self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
  if (self) {
    self.title = @"Street View";
  }
  return self;
}


- (void)viewDidLoad {
  [super viewDidLoad];
  
  self.view.backgroundColor = [UIColor whiteColor];
  
  UILabel *streetViewDataLoadingLabel = [[UILabel alloc] init];
  streetViewDataLoadingLabel.frame = CGRectMake(0, CGRectGetMidY(self.view.frame)-20, 320, 40);
  streetViewDataLoadingLabel.numberOfLines = 0;
  streetViewDataLoadingLabel.lineBreakMode = NSLineBreakByWordWrapping;
  streetViewDataLoadingLabel.textAlignment = NSTextAlignmentCenter;
  streetViewDataLoadingLabel.font = [UIFont fontWithDescriptor:[UIFontDescriptor fontDescriptorWithFontAttributes:@{NSFontAttributeName: @"Arial"}] size:19.0f];
  streetViewDataLoadingLabel.textColor = [UIColor grayColor];
  streetViewDataLoadingLabel.text = @"Loading Street View data";
  [self.view addSubview:streetViewDataLoadingLabel];
}


- (void)viewDidAppear:(BOOL)animated {
  [super viewDidAppear:animated];

  GMSPanoramaService *service = [[GMSPanoramaService alloc] init];
  [service requestPanoramaNearCoordinate:self.coordinate callback:^(GMSPanorama *panorama, NSError *error) {
    /* TODO: Inside of the callback, create a GMSPanoramaCamera object with the following properties:
     *       heading: 210
     *       pitch:   10
     *       zoom:    2
     *       FOV:     90
     */
    
    
    
    /* TODO: Still inside of the callback, create a GMSPanoramaView object, and set the camera and panorama
     *       properties to the camera you just created and the GMSPanorama object returned in the callback.
     */

    
    
    // TODO: Finally, still inside of the callback, set the main view to the GMSPanoramaView you just created

  
  
  }];
}


- (void)closeStreetView:(id)sender {
  [self.navigationController popToRootViewControllerAnimated:YES];
}

@end
