<Page name="home">
  <!-- Top Navbar -->
  <Navbar large sliding={false}>
    <NavTitleLarge>Mother Cluckers Coop Control</NavTitleLarge>
  </Navbar>
  <!-- Page content -->
  <Block strong>
    <p>Here is your blank Framework7 app. Let's see what we have here.</p>
  </Block>

  <BlockTitle>Navigation</BlockTitle>
  <List>
    <ListItem link="/about/" title="About"/>
    <ListItem link="/form/" title="Form"/>
  </List>

  

  <LoginScreen
    class="demo-login-screen"
    opened={loginScreenOpened}
    onLoginScreenClosed={() => loginScreenOpened = false}
  >
    <Page loginScreen>
      <LoginScreenTitle>Framework7</LoginScreenTitle>
      <List form>
        <ListInput
          label="PIN#"
          type="text"
          placeholder="Enter PIN"
          value={username}
          onInput={(e) => username = e.target.value}
        />
      </List>
      <List>
        <ListButton onClick={signIn}>Sign In</ListButton>
      </List>
      <BlockFooter>Some text about login information.<br />Lorem ipsum dolor sit amet, consectetur adipiscing elit.</BlockFooter>
    </Page>
  </LoginScreen>

</Page>
<script>
  import {
    Page,
    Navbar,
    NavTitleLarge,
    Block,
    BlockTitle,
    LoginScreen,
    BlockFooter,
    List,
    ListItem,
    ListInput
  } from 'framework7-svelte';
</script>