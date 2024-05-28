// Prevents additional console window on Windows in release, DO NOT REMOVE!!
#![cfg_attr(not(debug_assertions), windows_subsystem = "windows")]

#[cfg(windows)]
extern crate winapi;

// execute command
use std::process::Command;
#[tauri::command(rename_all = "snake_case")]
fn cmd(executable_path: String, arguments: String) {
    println!("Executing command: {} {}", executable_path, arguments);
    
    let child = Command::new(&executable_path)
        .args(&arguments.split_whitespace().collect::<Vec<&str>>())
        .spawn()
        .expect("failed to start installer");
}

fn main() {
    #[cfg(target_os = "windows")]
    unsafe {
        use winapi::um::shellscalingapi::{SetProcessDpiAwareness, PROCESS_SYSTEM_DPI_AWARE};
        let result = SetProcessDpiAwareness(PROCESS_SYSTEM_DPI_AWARE);
        if result != 0 {
            println!("Error setting DPI awareness: {}", result);
        }
    }

    tauri::Builder::default()
        .invoke_handler(tauri::generate_handler![cmd]) // custom command
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
