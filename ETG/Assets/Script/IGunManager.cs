public interface GunManager
{
    //총이 공통적으로 가지고 있어야할 스탯들 설정
    //총의 이름, 총의 연사속도,총알의 속도,총의 데미지, 최대탄창 수,최대 사거리
    string GunName { get; set; } //총이름
    float GunMax { get; set; } //총의 탄약갯수
    float BulletDamage { get; set; } //총의 데미지
    float BulletSpeed { get; set; } //총알의 스피드
    float Range { get; set; } //총알의 사거리
}