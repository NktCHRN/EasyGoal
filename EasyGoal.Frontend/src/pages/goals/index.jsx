// material-ui
import Grid from '@mui/material/Grid';
import Pagination from '@mui/material/Pagination';
import Box from '@mui/material/Box';
import Fab from '@mui/material/Fab'
import { useTheme } from '@mui/material/styles';

// project import
import PersonalGoalCard from 'components/cards/statistics/PersonalGoal';
import Search from './SearchGoals'
import { Tooltip } from '@mui/material';


const perPageCount = 12;
let page = 1;

export default function UserGoals() {
  const theme = useTheme();
  
  const fabStyle = {
    position: 'fixed',
    right: theme.spacing(5),
    bottom: theme.spacing(5),
  };

  return (
    <>
    <Grid container rowSpacing={4.5} columnSpacing={2.75}>
      <Grid item xs={12} sm={12} md={12} lg={12}>
      <Search></Search>
        </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <PersonalGoalCard name="Obtain Azure certification" description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eget turpis vel odio iaculis interdum. Nunc mauris lorem, fringilla vitae aliquet luctus, congue in arcu. Curabitur non justo tempor, ullamcorper sapien id, sollicitudin ante. Vivamus vel arcu non metus tincidunt laoreet. Mauris tristique, eros at sagittis congue, libero risus pulvinar lacus, eget auctor sapien turpis et orci. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla non ligula quis nisl scelerisque tincidunt in at lacus. Vivamus a malesuada sapien. Aenean sit amet turpis est. Cras id dui tellus. " doneTasks="7" totalTasks="50" doneTasksPercentage={14} deadline="24.06.2024" extra="35,000" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <PersonalGoalCard name="Learn more about DBs: Azure Cosmos DB, Cassandra" description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eget turpis vel odio iaculis interdum. Nunc mauris lorem, fringilla vitae aliquet luctus, congue in arcu. Curabitur non justo tempor, ullamcorper sapien id, sollicitudin ante. Vivamus vel arcu non metus tincidunt laoreet. Mauris tristique, eros at sagittis congue, libero risus pulvinar lacus, eget auctor sapien turpis et orci. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla non ligula quis nisl scelerisque tincidunt in at lacus. Vivamus a malesuada sapien. Aenean sit amet turpis est. Cras id dui tellus. " doneTasks="5" totalTasks="6" doneTasksPercentage={83.3333} deadline="24.06.2024" extra="35,000" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <PersonalGoalCard name="Learn more about DDD" description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eget turpis vel odio iaculis interdum. Nunc mauris lorem, fringilla vitae aliquet luctus, congue in arcu. Curabitur non justo tempor, ullamcorper sapien id, sollicitudin ante. Vivamus vel arcu non metus tincidunt laoreet. Mauris tristique, eros at sagittis congue, libero risus pulvinar lacus, eget auctor sapien turpis et orci. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla non ligula quis nisl scelerisque tincidunt in at lacus. Vivamus a malesuada sapien. Aenean sit amet turpis est. Cras id dui tellus. " doneTasks="33" totalTasks="33" doneTasksPercentage={100} deadline="24.06.2024" extra="35,000" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <PersonalGoalCard name="Learn more about caching, strategies, types" description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eget turpis vel odio iaculis interdum. Nunc mauris lorem, fringilla vitae aliquet luctus, congue in arcu. Curabitur non justo tempor, ullamcorper sapien id, sollicitudin ante. Vivamus vel arcu non metus tincidunt laoreet. Mauris tristique, eros at sagittis congue, libero risus pulvinar lacus, eget auctor sapien turpis et orci. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla non ligula quis nisl scelerisque tincidunt in at lacus. Vivamus a malesuada sapien. Aenean sit amet turpis est. Cras id dui tellus. " doneTasks="30" totalTasks="30" doneTasksPercentage={100} deadline="24.06.2024" extra="35,000" />
      </Grid>
      <Grid item xs={12} sm={6} md={4} lg={3}>
        <PersonalGoalCard name="Improve my English level" description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eget turpis vel odio iaculis interdum. Nunc mauris lorem, fringilla vitae aliquet luctus, congue in arcu. Curabitur non justo tempor, ullamcorper sapien id, sollicitudin ante. Vivamus vel arcu non metus tincidunt laoreet. Mauris tristique, eros at sagittis congue, libero risus pulvinar lacus, eget auctor sapien turpis et orci. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla non ligula quis nisl scelerisque tincidunt in at lacus. Vivamus a malesuada sapien. Aenean sit amet turpis est. Cras id dui tellus. " doneTasks="90" totalTasks="101" doneTasksPercentage={89.11} deadline="24.06.2024" extra="35,000" />
      </Grid>
      <Grid item xs={12} sm={12} md={12} lg={12}>
      <Box display="flex" justifyContent="center">
        <Pagination count={1} variant="outlined" />
        </Box>
      </Grid>
    </Grid>
    <Tooltip title="Add personal goal">
      <Fab color='primary' size="large" sx={fabStyle}>
              +
            </Fab>
    </Tooltip>
    </>
  );
}
