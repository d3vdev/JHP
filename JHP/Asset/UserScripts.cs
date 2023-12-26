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
        const links = container.querySelectorAll('div.App > div > div > div > div > div > div > div > div > div > div > button');
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
    }
}

