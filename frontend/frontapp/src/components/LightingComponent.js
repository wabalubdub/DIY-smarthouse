const API_PORT = process.env.API_PORT || 3005;

export default function LightingComponent({ text, Edge_device_ID, light_ID }) {
  return (
    <div class='rectangle-component outline-green'>
      <p>{text}</p>
      <div className='buttons-container'>
        <Light_Button
          button_text='on'
          Edge_device_ID={Edge_device_ID}
          light_ID={light_ID}
          mode='on'
        />
        <Light_Button
          button_text='off'
          Edge_device_ID={Edge_device_ID}
          light_ID={light_ID}
          mode='off'
        />
      </div>
    </div>
  );
}
function turn_light(mode, light_ID, Edge_device_ID) {
  var content = {
    mode: mode,
    light_ID: light_ID,
    Edge_device_ID: Edge_device_ID,
  };
  return async () => {
    try {
      const response = await fetch(`https://localhost:${API_PORT}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(content),
      });

      const jsonData = await response.json();
      if (response.status > 200) {
        alert(response.status);
      }
    } catch (error) {
      console.error("Error posting data:", error);
    }
  };
}

function Light_Button({ button_text, Edge_device_ID, light_ID, mode }) {
  return (
    <button
      class='button'
      onClick={turn_light({ mode, light_ID, Edge_device_ID })}
    >
      {button_text}
    </button>
  );
}
