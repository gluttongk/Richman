namespace Core.Scene
{
    public interface ISceneManager
    {
        /// <summary>
        /// 动态切换场景
        /// </summary>
        /// <param name="scene">场景名枚举</param>
        void ChangeScene( Scene scene );
    }
}
