import * as React from 'react';
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';
import StorefrontIcon from '@mui/icons-material/Storefront';
import ListItemText from '@mui/material/ListItemText';
import ContentCutOutlinedIcon from '@mui/icons-material/ContentCutOutlined';
import { ListItemIcon } from '@mui/material';


export default function Step1() {
  const [selectedIndex, setSelectedIndex] = React.useState(1);
  const [selectedBusiness, setSelectedBusiness] = React.useState(null);

  const handleListItemClick = (event, index) => {
      //this function sets business id into state
    setSelectedIndex(index);
  };



  //use effect to populate list of businesses
  return (
    <Box sx={{ width: '100%', maxWidth: 360, bgcolor: 'background.paper' }}>
     
      <List component="nav" aria-label="secondary mailbox folder">
     
        <ListItemButton
          selected={selectedIndex === 1}
          onClick={(event) => handleListItemClick(event, 2)}
        >
        <ListItemIcon>
            <StorefrontIcon/>
          </ListItemIcon>
          <ListItemText primary="Studio 786 Salon" />
        </ListItemButton>
        <ListItemButton
          selected={selectedIndex === 2}
          onClick={(event) => handleListItemClick(event, 3)}
        >
            <ListItemIcon>
                <ContentCutOutlinedIcon/>
            </ListItemIcon>
          <ListItemText primary="Illy's" />
        </ListItemButton>
      </List>
    </Box>
  );
}