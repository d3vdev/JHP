using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHP.Asset
{
    internal class UserScripts
    {
        public static string LaftelSkipNext = @"
(async () => {
    // MutationObserver 초기화
    const container = document.getElementById('root');
    const config = { childList: true, subtree: true };
    const observer = new MutationObserver((m, o) => {
        const links = container.querySelectorAll('div > div > div > div > div > div > div > div > div > div > button');
        for (const link of links) {
            if (link.innerText.indexOf(""바로 재생"") !== -1) {
                console.log('click');
                link.click();
                return;
            }
        }
    });

    const origFunc = history.pushState;
    history.pushState = function () {
        const result = origFunc.apply(window.history, arguments);
        window.dispatchEvent(new Event('pushstate'));
        return result;
    };

    // 다음화 찾기 함수
    const checkNext = () => {
        if (window.location.pathname.indexOf('player') === 1) {
            observer.observe(container, config);
            return;
        }
        observer.disconnect();
    }

    // 스크립트 끄고 켜기
    const turnOnScript = () => {
        window.addEventListener('popstate', checkNext);
        window.addEventListener('pushstate', checkNext);
        checkNext();
    }


    // 스크립트 시작
    window.addEventListener('load', (e) => {
        console.log('라프텔');
        turnOnScript();
    })
})();";

        public static string NetflixSkipNext = @"
(async () => {
    // MutationObserver 초기화
    const container = document.getElementById('appMountPoint');
    const config = { childList: true, subtree: true };
    const observer = new MutationObserver((m, o) => {
        const links = container.querySelectorAll('div > div.watch-video--skip-content > button');
        for (const link of links) {
            if (link.innerText.indexOf(""오프닝 건너뛰기"") !== -1) {
                console.log('click');
                link.click();
                return;
            }
        }

        const links2 = container.querySelectorAll('#appMountPoint > div > div > div > div > div > div.active > div.SeamlessControls--container.SeamlessControls--container-visible > div > button');
        for (const link of links2) {
            console.log(link.innerText)
            if (link.innerText.indexOf(""다음 화"") !== -1) {
                console.log('click');
                link.click();
                return;
            }
        }
    });

    const origFunc = history.pushState;
    history.pushState = function () {
        const result = origFunc.apply(window.history, arguments);
        window.dispatchEvent(new Event('pushstate'));
        return result;
    };

    // 다음화 찾기 함수
    const checkNext = () => {
        if (window.location.pathname.indexOf('watch') === 1) {
            observer.observe(container, config);
            return;
        }
        observer.disconnect();
    }

    // 스크립트 끄고 켜기
    const turnOnScript = () => {
        window.addEventListener('popstate', checkNext);
        window.addEventListener('pushstate', checkNext);
        checkNext();
    }


    // 스크립트 시작
    window.addEventListener('load', (e) => {
        console.log('Netflix');
        turnOnScript();
    })
})();";
    }
}

