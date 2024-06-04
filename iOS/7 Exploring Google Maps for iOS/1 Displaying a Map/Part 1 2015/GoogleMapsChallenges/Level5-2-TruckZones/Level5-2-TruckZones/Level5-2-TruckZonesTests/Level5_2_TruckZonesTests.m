#import <XCTest/XCTest.h>
#import <GoogleMaps/GoogleMaps.h>
#import <objc/runtime.h>

#import "CSRecordingTestCase.h"
#import "CSPropertyDefinition.h"

#import "AppDelegate.h"
#import "AppDelegate+TestAdditions.h"

#import "TruckMapVC+Swizzles.h"

#define kDoubleEpsilon (0.000001)

static BOOL doubleCloseTo(double a, double b){
  if (fabs(a-b) < kDoubleEpsilon) {
    return YES;
  }else{
    return NO;
  }
}
@interface Level5_2_TruckZonesTests : CSRecordingTestCase {}

@end

@implementation Level5_2_TruckZonesTests

- (void)setUp {
  [super setUp];
}

- (void)tearDown {
  [super tearDown];
}

- (void)testMeltHousePolygonDrawn
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  GMSPolygon *polygon1 = appDel.polygons[0];
  GMSPolygon *polygon2;
  if(appDel.polygons.count == 2) {
    polygon2 = appDel.polygons[1];
  }
  
  NSString *meltHouseExpectedPath = @"wzveFpkjjV?EG_AM}AA@@EQiCS}CQsCSoCKeBSQ{APMLLlBFfA@`@Bb@@V?FC@AGAWC?G[AK?CAE?GOcCQALCACEo@CG?CAECCC?AAE?G@EAC@_@FC?A?CAACACAC?C?C?C@CBCBC@?BAB?b@CBABA@ABC?EG@iALFn@E@Gs@RCAIWITBAGUIRD@CAEWIRD@CCWWIRD@ACQOGL@CQOEL@ASOEL@AGMGHBBCAEOGL@COKEH?AOMEJ?AOMEH?AQMEJ@RCMDBPNAMDA@DNLAKDABBLNAODBNNAMBABBJ@B?BBLJ?KD@LBBABBJ@BABBLJAID@J@BABBH@BABBJJAID@Nr@IAOK?JCAMAA@CAMM?JC?MAA@CAKAC@CAMCABCCOKAJCAMAC@CAMAA?C?CO?JC@CAC@EAMCA@CAOAC@CCOM?PCH~@?FDb@P~CFA?OACACAE?EAE?C?G?E?CAE?CAC?E?G?EAE?C?CAC?C?CAC?CAY?M?KCE?GCI?OAM?GAOAC?WASAYCOASCo@Em@Gm@EYAYAa@A[IaAK}AGcAGu@Ec@CYCW?UCWG[Cc@ESAI@ICi@CK?O?c@A]WDs@cKFUu@_@Ty@CJCHCJCHCJHDFBHBFDFBFDBEB?K`@p@|JDANE?C@C@CBCB?RGPALAbAM?EQ@PGBD@C@EA_@Cm@Eq@KyAA[?C?C?C@EBC@C@ABADAHEDABABABAB??IEEBEAMCC@EAKAC@EAKCCBEAICC@C?KCC@EAIAC@CAICCBEAICC@E?ICE@CAQB?@PB@CD@JBBAB?JBBAD@J@@AD@JB@CD@JBBAB?HBBAB@J@BAB@H@BAB@JB@CD@L@FB?B?d@EBA@ABA@E@DD?B?FARGH@JAz@MRCBA@ABC@ABE@C@C@C@C?C@C?E?E?C?C?CACY_DAEACCAACCAAAC?AASSEU@XPTA@QUEYMAG@q@PAGi@LACj@MAEz@S@LL@AED??EACCCAC?ECGCACACAC@EB?BKBCCEAE@I@}APy@LsGd@CFAA?s@`Gs@FOMoBKIuIbAGmApIcAHOMoBMKuI~@IeBtGu@MsBM@wAmEz@wFE?cBlBLzAYDOeBFAEk@JADf@hBsBFMAC^KpEqCvAuA`YaDh\\aEbP`gCX|Eyi@~EJrAuAjDoCvAcB@eCs@cAeAm@_BoB@?[_Gp@MkC_CRO]uAaCGkB?_@UsFBuA?C?CSmEAOq@aEEOCUCa@KsBEm@GcAEq@Ow@ACACACACACACCCACCCCCCCACAACCCCCA_@]OSOQHSnBdA@B@@BB?B@B@B@B@D?BD`@@\\ThE?DJbB@JFFJDD?AOACE?E_AZC@BYBB^@@ZC[F@NZE@BWD?BHFIA@HXGFx@e@BCH?DBTBRBJ@LBLBJ?FDXLn@VAFj@Jz@D^HZR~@XzAHGAY?EBRBBFKGw@Fd@DDDIAWLAGs@Hz@IPLG@BQHIN\\M?Ba@NGNDXn@U?Bm@TDPl@W?Bm@VDLl@U?@m@VFVRIB?Qp@G_@G@b@|B?WCM@CIe@BAXiAB@]lAH\\^wA@@_@zADR`@w@@Bc@x@FT`@u@@Bc@t@FTR_@@BOX@ADPKB@LNl@C@Om@E@Pt@PA@CBBBABA@@FACg@B`@BBNC@CB@NA@CB@B?@CB@B?@CB@NCAg@Bd@@@NA@C@@D?@A@?B?BC@BBA@AD@BE@BHABCB@@AAQB?@PLAMFuBVq@H[DS@\\dBh@IXATCNG@EB?BBR?ZE\\EVECq@CCEi@CE";
  
  CLLocationCoordinate2D polygon1Coordinate0 = [polygon1.path coordinateAtIndex:0];
  
  GMSPolygon *meltHousePolygon;
  
  if(doubleCloseTo(polygon1Coordinate0.latitude, 37.805401) && doubleCloseTo(polygon1Coordinate0.longitude, -122.446806)) {
    meltHousePolygon = polygon1;
  } else {
    meltHousePolygon = polygon2;
  }
  
  if(meltHousePolygon != nil) {
    XCTAssert([meltHousePolygon.path.encodedPath isEqualToString:meltHouseExpectedPath], @"Did not use the correct path for Melt House");
    const float* meltHouseStrokeColors = CGColorGetComponents(meltHousePolygon.strokeColor.CGColor);
    XCTAssert(doubleCloseTo(meltHouseStrokeColors[0], 0.980392) && doubleCloseTo(meltHouseStrokeColors[1], 0.686275) && doubleCloseTo(meltHouseStrokeColors[2], 0.25098) && doubleCloseTo(meltHouseStrokeColors[3], 1.00000), @"Did not use the right stroke color for the Melt House polygon");
    const float* meltHouseFillColors = CGColorGetComponents(meltHousePolygon.fillColor.CGColor);
    XCTAssert(doubleCloseTo(meltHouseFillColors[0], 0.980392) && doubleCloseTo(meltHouseFillColors[1], 0.686275) && doubleCloseTo(meltHouseFillColors[2], 0.25098) && doubleCloseTo(meltHouseFillColors[3], 0.50000), @"Did not use the right fill color for the Melt House polygon");
    XCTAssert(meltHousePolygon.strokeWidth == 2, @"Did not use the right strokeWidth for the Melt House polygon");
  } else {
    XCTFail(@"Did not create a polygon for the Melt House zone");
  }
}

- (void)testTacoGogoPolygonDrawn
{
  AppDelegate *appDel = (AppDelegate *)[[UIApplication sharedApplication] delegate];
  
  GMSPolygon *polygon1 = appDel.polygons[0];
  GMSPolygon *polygon2;
  if(appDel.polygons.count == 2) {
    polygon2 = appDel.polygons[1];
  }
  
  NSString *tacoGogoExpectedPath = @"iiseFtkjjVcNnAkKtAi@}G_Q|AY}EcPagCxJkAlUsCbJiAjQjqC^vE";
  
  CLLocationCoordinate2D polygon2Coordinate0 = [polygon2.path coordinateAtIndex:0];
  
  GMSPolygon *tacoGogoPolygon;
  
  if(doubleCloseTo(polygon2Coordinate0.latitude, 37.787251) && doubleCloseTo(polygon2Coordinate0.longitude, -122.446825)) {
    tacoGogoPolygon = polygon2;
  } else {
    tacoGogoPolygon = polygon1;
  }
  
  if(tacoGogoPolygon != nil) {
    XCTAssert([tacoGogoPolygon.path.encodedPath isEqualToString:tacoGogoExpectedPath], @"Did not use the correct path for Taco Gogo");
    const float* tacoGogoStrokeColors = CGColorGetComponents(tacoGogoPolygon.strokeColor.CGColor);
    XCTAssert(doubleCloseTo(tacoGogoStrokeColors[0], 0.309804) && doubleCloseTo(tacoGogoStrokeColors[1], 0.741176) && doubleCloseTo(tacoGogoStrokeColors[2], 0.784314) && doubleCloseTo(tacoGogoStrokeColors[3], 1.00000), @"Did not use the right stroke color for the Taco Gogo polygon");
    const float* tacoGogoFillColors = CGColorGetComponents(tacoGogoPolygon.fillColor.CGColor);
    XCTAssert(doubleCloseTo(tacoGogoFillColors[0], 0.309804) && doubleCloseTo(tacoGogoFillColors[1], 0.741176) && doubleCloseTo(tacoGogoFillColors[2], 0.784314) && doubleCloseTo(tacoGogoFillColors[3], 0.50000), @"Did not use the right fill color for the Taco Gogo polygon");
    XCTAssert(tacoGogoPolygon.strokeWidth == 2, @"Did not use the right strokeWidth for the Taco Gogo polygon");
  } else {
    XCTFail(@"Did not create a polygon for the Taco Gogo zone");
  }
}

@end
