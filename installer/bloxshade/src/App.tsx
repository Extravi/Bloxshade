import { useEffect, useState } from 'react';
import { open } from '@tauri-apps/api/shell';
import { fs } from '@tauri-apps/api';
import { invoke } from '@tauri-apps/api/tauri';
import './script.js';

interface Preset {
  title: string;
  description: string;
  author: string;
  source: string;
}

function App() {
  const [presets, setPresets] = useState<Preset[]>([]);

  useEffect(() => {
    fetchPresets();
  }, []);

  const fetchPresets = async () => {
    try {
      const response = await fetch('https://extravi.dev/update/presets.json');
      const data = await response.json();
      setPresets(data.presets);
    } catch (error) {
      console.error('Error fetching presets:', error);
    }
  };

  const openLink = async (url: string) => {
    try {
      await open(url);
      console.log('Link opened successfully');
    } catch (error) {
      console.error('Error opening link:', error);
    }
  };

  function checkCheckboxStatus(): void {
    const checkboxes = ["box-0", "box-1", "box-2", "box-3"];
    const links = [
      'https://www.youtube.com/channel/UCOZnRzWstxDLyW30TjWEevQ?sub_confirmation=1',
      'https://discord.gg/TNG5yHsEwu',
      'https://reshade.me/',
      'https://extravi.dev/'
    ];

    checkboxes.forEach((box, index) => {
      const checkbox = document.getElementById(box) as HTMLInputElement;
      if (checkbox.checked) {
        openLink(links[index]);
      }
    });
    // close installer
    window.close();
  }

  async function createBloxshadeFolder() {
    const bloxshadeFolderPath = 'C:\\Program Files\\Bloxshade';
    const installLogPath = `${bloxshadeFolderPath}\\install.txt`; // install log path

    try {
      await fs.writeFile(installLogPath, ''); // create install log file

      // start installer
      invoke('cmd', { executable_path: `${bloxshadeFolderPath}\\installer.exe`, arguments: '' });

      let lastReadPosition = 0;

      while (true) {
        const fileContent = await fs.readTextFile(installLogPath);

        const newContent = fileContent.substring(lastReadPosition);
        const lines = newContent.split('\n');

        let newText = '';

        for (const line of lines) {
          if (line.trim() !== '') {
            newText += `${line.trim()}<br>`;
          }

          if (line.trim() === '0') {
            console.log('0');

            // done installing go to last page
            const element1: HTMLElement | null = document.getElementById("con-1");
            const element2: HTMLElement | null = document.getElementById("con-4");

            if (element1 && element2) {
              element1.classList.remove("show");
              element1.classList.add("hide");

              element2.classList.remove("hide");
              element2.classList.add("show");
            } else {
              console.error("One or both elements not found.");
            }

            return; // exit loop
          }
        }

        // scroll down the textbox
        const textbox: HTMLElement | null = document.getElementById('textbox');

        function scrollTextbox(): void {
          if (textbox) {
            textbox.scrollTop = textbox.scrollHeight;
          }
        }

        // update textbox
        const textBox = document.querySelector('.textbox p');
        if (textBox) {
          textBox.innerHTML += newText;
          scrollTextbox();
        }

        lastReadPosition = fileContent.length;

        await new Promise(resolve => setTimeout(resolve, 50)); // wait
      }

    } catch (error) {
      console.error('Error creating Bloxshade folder:', error);
    }
  }

  async function shortcut() {
    const bloxshadeFolderPath = 'C:\\Program Files\\Bloxshade';
    const installLogPath = `${bloxshadeFolderPath}\\install.txt`; // install log path

    try {
      await fs.writeFile(installLogPath, ''); // create install log file

      // start installer
      invoke('cmd', { executable_path: `${bloxshadeFolderPath}\\installer.exe`, arguments: '-shortcut' });
    } catch (error) {
      console.error(error);
    }
  }

  async function importPreset() {
    const bloxshadeFolderPath = 'C:\\Program Files\\Bloxshade';
    const installLogPath = `${bloxshadeFolderPath}\\install.txt`; // install log path

    try {
      await fs.writeFile(installLogPath, ''); // create install log file

      // start installer
      invoke('cmd', { executable_path: `${bloxshadeFolderPath}\\installer.exe`, arguments: '-import' });
    } catch (error) {
      console.error(error);
    }
  }

  async function fix() {
    const bloxshadeFolderPath = 'C:\\Program Files\\Bloxshade';
    const installLogPath = `${bloxshadeFolderPath}\\install.txt`; // install log path

    try {
      await fs.writeFile(installLogPath, ''); // create install log file

      // start installer
      invoke('cmd', { executable_path: `${bloxshadeFolderPath}\\installer.exe`, arguments: '-fix' });
    } catch (error) {
      console.error(error);
    }
  }

  const userPreset = async (source: string) => {
    const bloxshadeFolderPath = 'C:\\Program Files\\Bloxshade';
    try {
      console.log(source);
      // todo
      invoke('cmd', { executable_path: `${bloxshadeFolderPath}\\installer.exe`, arguments: `-install "${source}"` });
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <div className="side-img"></div>
      {/* content 0 */}
      <div id="con-0" className="content show">
        <h1>Bloxshade - Improve Roblox<br></br>with shaders.</h1>
        <p>This installer will set up and configure ReShade
          FX shaders tailored for Nvidia Ansel on
          your computer.
          <br></br>
          <br></br>
          Before continuing, ensure that Roblox is closed.
          If Roblox is open, the installer will terminate
          the process before it begins.
          <br></br>
          <br></br>
          There may be issues with the setup.
          If that's the case, it's recommended that you ask
          your questions in Bloxshade's Discord server.
          <br></br>
          <br></br>
          Click Install to continue.
        </p>
        <a id="set" className="settings">Settings</a>
        <a id="set-acknowledgements" className="settings con-0">Acknowledgements</a>
        <button id="install" className="btn" onClick={createBloxshadeFolder}>Install</button>
      </div>
      {/* content 1 */}
      <div id="con-1" className="content hide">
        <h1>Bloxshade - Improve Roblox<br></br>with shaders.</h1>
        <h1 className="installing">Installing...</h1>
        <p>Please wait while Bloxshade is being installed.</p>
        <div id="textbox" className="textbox">
          <p></p>
        </div>
        <button className="btn btn-2">Next</button>
      </div>
      {/* content 2 */}
      <div id="con-2" className="content hide">
        <h1>Bloxshade - Improve Roblox<br></br>with shaders.</h1>
        <p>Setup has finished installing Bloxshade on your
          computer. The effects will be applied the next
          time you launch Roblox.
          <br></br>
          <br></br>
          Click Finish to exit Setup.
        </p>
        <div className="container">
          <label>
            <input id="box-0" type="checkbox" />
            <span className="box">Subscribe to Extravi on Youtube</span>
          </label>
        </div>
        <div className="container">
          <label>
            <input id="box-1" type="checkbox" />
            <span className="box">Join our Discord server</span>
          </label>
        </div>
        <div className="container">
          <label>
            <input id="box-2" type="checkbox" />
            <span className="box">Visit reshade.me</span>
          </label>
        </div>
        <div className="container">
          <label>
            <input id="box-3" type="checkbox" />
            <span className="box">Visit extravi.dev</span>
          </label>
        </div>
        <button className="btn" onClick={checkCheckboxStatus}>Finish</button>
      </div>
      {/* content 3 */}
      <div id="con-3" className="content hide">
        <h1>Bloxshade - Improve Roblox<br></br>with shaders.</h1>
        <p className="p-settings">If you have already installed Bloxshade, you can manage Roblox from here or configure your installation.</p>
        <button id="btn-0" className="btn-settings" onClick={shortcut}>Create shortcuts</button>
        <p className="p-settings">Bloxshade FX issues (menu/effects not working).</p>
        <button id="btn-1" className="btn-settings" onClick={fix}>Fix Bloxshade FX</button>
        <p className="p-settings">Install your own Ansel presets.</p>
        <button id="btn-2" className="btn-settings" onClick={importPreset}>Import your own Ansel preset</button>
        <a id="dis" className="settings-settings" onClick={() => openLink('https://discord.com/invite/TNG5yHsEwu')}>Join our Discord server.</a>
        <a className="settings-settings extravi" onClick={() => openLink('https://extravi.dev/')}>extravi.dev</a>
        <a id="uwu" className="settings-settings uwu">Back</a>
      </div>
      {/* content 4 */}
      <div id="con-4" className="content hide">
        <h1>Community presets</h1>
        <p className="c-settings">Download and install community presets</p>
        <div className='results'>
          {presets.map((preset, index) => (
            <div key={index} className={index === 0 ? 'results-div-1' : 'results-div'}>
              <div className='results-row'>
                <p><span>{preset.title}</span></p>
                <p><span>{preset.description}</span></p>
                <p><span className="highlight">Author: </span><span>{preset.author}</span><a className='uwu-rar' onClick={() => userPreset(preset.source)}>Install</a></p>
              </div>
            </div>
          ))}
        </div>
        <button id="userPresets" className="btn btn-p">Next</button>
      </div>
      {/* content 5 */}
      <div id="con-5" className="content hide">
        <h1>Acknowledgements</h1>
        <p className="c-settings">Open source repositories Bloxshade uses</p>
        <div className='results'>
          <div className='results-div-1'>
            <div className='results-row'>
              <p><span>dh-reshade-shaders</span></p>
              <p><span className="highlight">Author: </span><span>AlucardDH</span><a className='uwu-rar' onClick={() => openLink('https://github.com/AlucardDH')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>AstrayFX</span></p>
              <p><span className="highlight">Author: </span><span>BlueSkyDefender</span><a className='uwu-rar' onClick={() => openLink('https://github.com/BlueSkyDefender')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>SweetFX</span></p>
              <p><span className="highlight">Author: </span><span>CeeJayDK</span><a className='uwu-rar' onClick={() => openLink('https://github.com/CeeJayDK')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>Bloxshade</span></p>
              <p><span className="highlight">Author: </span><span>Extravi</span><a className='uwu-rar' onClick={() => openLink('https://github.com/Extravi')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>fubax-shaders</span></p>
              <p><span className="highlight">Author: </span><span>Fubaxiusz</span><a className='uwu-rar' onClick={() => openLink('https://github.com/Fubaxiusz')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>reshade-shaders</span></p>
              <p><span className="highlight">Author: </span><span>crosire</span><a className='uwu-rar' onClick={() => openLink('https://github.com/crosire')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>FXShaders</span></p>
              <p><span className="highlight">Author: </span><span>luluco250</span><a className='uwu-rar' onClick={() => openLink('https://github.com/luluco250')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>qUINT</span></p>
              <p><span className="highlight">Author: </span><span>martymcmodding</span><a className='uwu-rar' onClick={() => openLink('https://github.com/martymcmodding')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>NiceGuy-Shaders</span></p>
              <p><span className="highlight">Author: </span><span>mj-ehsan</span><a className='uwu-rar' onClick={() => openLink('https://github.com/mj-ehsan')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>ZealShaders</span></p>
              <p><span className="highlight">Author: </span><span>bituq</span><a className='uwu-rar' onClick={() => openLink('https://github.com/bituq')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>AcMotionBlur</span></p>
              <p><span className="highlight">Author: </span><span>papadanku</span><a className='uwu-rar' onClick={() => openLink('https://github.com/papadanku')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>prod80-ReShade-Repository</span></p>
              <p><span className="highlight">Author: </span><span>prod80</span><a className='uwu-rar' onClick={() => openLink('https://github.com/prod80')}>Visit</a></p>
            </div>
          </div>
          <div className='results-div'>
            <div className='results-row'>
              <p><span>Glamarye_Fast_Effects_for_ReShade</span></p>
              <p><span className="highlight">Author: </span><span>rj200</span><a className='uwu-rar' onClick={() => openLink('https://github.com/rj200')}>Visit</a></p>
            </div>
          </div>
        </div>
        <a id="acknowledgements" className="settings">Back</a>
      </div>
    </>
  )
}

export default App
